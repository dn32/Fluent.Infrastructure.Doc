using Fluent.Architecture.Services;
using System.Threading.Tasks;
using Fluent.Architecture.Core.Models;

namespace MVCWebSite.product_scope
{
    public class ProductSaleService : FluentService<ProductSale>
    {
        protected virtual FluentService<Product> ProductService => null;
        protected virtual FluentService<Sale> SaleService => null;

        private decimal CalculateTotalValue(ProductSale sale)
        {
            //Todo - calculate discount here
            return sale.Product.Value * sale.Quantity;
        }

        public async Task AddAsync(int productId, int saleId, decimal quantity)
        {
            var productTask = ProductService.FindAsync(new Product { Id = productId });
            var saleTask = SaleService.FindAsync(new Sale { Id = saleId });

            var productSale = new ProductSale
            {
                Quantity = quantity,
                ProductId = productId,
                Product = await productTask,
                Sale = await saleTask
            };

            productSale.TotalValue = CalculateTotalValue(productSale);

            await AddAsync(productSale);
        }
    }
}

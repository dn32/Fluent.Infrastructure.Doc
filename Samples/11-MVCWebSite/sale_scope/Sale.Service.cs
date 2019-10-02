using Fluent.Architecture.Services;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebSite.product_scope
{
    public class SaleService : FluentService<Sale>
    {
        public async Task FinalizeSale(int saleId)
        {
            var sale = await FindAsync(new Sale { Id = saleId });
            sale.TotalQuantityOfProducts = sale.ProductSaleList.Sum(X => X.Quantity);
            sale.TotalValue = sale.ProductSaleList.Sum(X => X.TotalValue);
            sale.IsFinalizer = true;
            await UpdateAsync(sale);
        }
    }
}

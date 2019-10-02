using Fluent.Architecture.Validation;
using System.Threading.Tasks;

namespace MVCWebSite.product_scope
{
    public class ProductSaleValidation : FluentValidation<ProductSale>
    {
        public override Task AddAsync(ProductSale entity)
        {
            if (entity.Sale.IsFinalizer)
            {
                AddInconsistency(new SaleAlreadyCompletedException("This Sale has already been completed"));
            }

            return base.AddAsync(entity);
        }
    }
}

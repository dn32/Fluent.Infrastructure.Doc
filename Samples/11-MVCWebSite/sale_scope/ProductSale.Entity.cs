using Fluent.Architecture.Interfaces;
using MVCWebSite.base_elements;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCWebSite.product_scope
{
    public class ProductSale : MvcBaseEntity, IFluentInclusionEntity
    {
        public int ProductId { get; set; }

        public int SaleId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [ForeignKey(nameof(SaleId))]
        public Sale Sale { get; set; }

        public decimal TotalValue { get; set; }

        public decimal Quantity { get; set; }

        public string[] InclusionsForList => new[] { nameof(Product), nameof(Sale) };

        public string[] InclusionsForOne => new[] { nameof(Product), nameof(Sale) };
    }
}

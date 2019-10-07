using Fluent.Architecture.Core.Attributes;
using Fluent.Architecture.Interfaces;
using MVCWebSite.base_elements;
using MVCWebSite.client_scope;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCWebSite.product_scope
{
    public class Sale : MvcBaseEntity, IFluentInclusionEntity
    {
        public int ProductSaleId { get; set; }

        public int ClientId { get; set; }

        public decimal TotalValue { get; set; }

        public decimal TotalQuantityOfProducts { get; set; }

        public bool IsFinalizer { get; set; }

        [ForeignKey(nameof(ProductSaleId)), FluentAggregation(LocalKey = nameof(Id), ExternalKey = nameof(ProductSaleId))]
        public IEnumerable<ProductSale> ProductSaleList { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }

        public string[] InclusionsForList => new[] { nameof(ProductSaleList), nameof(Client) };

        public string[] InclusionsForOne => new[] { nameof(ProductSaleList), nameof(Client), $"{nameof(ProductSaleList)}.{nameof(ProductSale.Product)}" };
    }
}

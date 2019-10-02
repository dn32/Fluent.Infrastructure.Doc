using Fluent.Architecture.Attributes;
using Fluent.Architecture.Interfaces;
using MVCWebSite.base_elements;
using MVCWebSite.brand_scope;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCWebSite.product_scope
{
    public class Product : MvcBaseEntity, IFluentInclusionEntity
    {
        [FluentUniqueKey]
        public string Name { get; set; }

        public decimal Value { get; set; }

        public int BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }

        public string[] InclusionsForList => new[] { nameof(Brand) };

        public string[] InclusionsForOne => new[] { nameof(Brand) };
    }
}

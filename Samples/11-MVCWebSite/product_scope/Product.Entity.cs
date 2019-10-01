using Fluent.Architecture.Core.Attributes;
using Fluent.Architecture.Entities;
using Fluent.Architecture.Interfaces;
using MVCWebSite.brand_scope;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCWebSite.product_scope
{
    public class Product : FluentEntity, IFluentInclusionEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]//, FluentAggregation(LocalKey = nameof(BrandId), ExternalKey = nameof(brand_scope.Brand.Id))]
        public Brand Brand { get; set; }

        public string[] InclusionsForList => new[] { nameof(Brand) };

        public string[] InclusionsForOne => new[] { nameof(Brand) };
    }
}

using Fluent.Architecture.Core.Attributes;
using Fluent.Architecture.Core.Models;
using Fluent.Architecture.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Composition.Entities
{
    public class User : FluentEntity, IFluentInclusionEntity
    {
        [Key]
        public int Code { get; set; }

        [FluentAggregation(LocalKey = nameof(CompanyCode), ExternalKey = nameof(Entities.Company.Code))]
        [ForeignKey(nameof(CompanyCode))]
        public Company Company { get; set; }

        public int CompanyCode { get; set; }

        public string Name { get; set; }

        public string[] InclusionsForList => new[] { nameof(Company) };

        public string[] InclusionsForOne => new[] { nameof(Company) };
    }
}
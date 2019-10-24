using Fluent.Architecture.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Composition.Entities
{
    public class Company : FluentEntity
    {
        [Key]
        public int Code { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(DepartmentCode))]
        public Department Department { get; set; }

        public int DepartmentCode { get; set; }
    }
}
using Fluent.Architecture.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Composition.Entities
{
    public class Department : FluentEntity
    {
        [Key]
        public int Code { get; set; }

        public string Name { get; set; }
    }
}
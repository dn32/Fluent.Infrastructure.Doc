using Fluent.Architecture.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCWebSite.brand_scope
{
    public class Brand : FluentEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

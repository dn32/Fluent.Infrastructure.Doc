using Fluent.Architecture.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCWebSite.base_elements
{
    public abstract class MvcBaseEntity : FluentEntity
    {
        [Key]
        public int Id { get; set; }
    }
}

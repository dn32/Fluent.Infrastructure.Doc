using Fluent.Architecture.Attributes;
using MVCWebSite.base_elements;

namespace MVCWebSite.brand_scope
{
    public class Brand : MvcBaseEntity
    {
        [FluentUniqueKey]
        public string Name { get; set; }
    }
}

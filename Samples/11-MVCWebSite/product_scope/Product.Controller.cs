using Fluent.Architecture.Extensions;
using Microsoft.AspNetCore.Mvc;
using MVCWebSite.base_elements;
using MVCWebSite.product_scope;
using System.Threading.Tasks;

namespace MVCWebSite.Controllers
{
    public class ProductController : MvcBaseController<Product>
    {
        public new ProductService Service => base.Service.FluentCast<ProductService>();

        public override IActionResult New()
        {
            ViewBag.Brands = Service.GetBrandsAsync().Result;
            return base.New();
        }

        public override async Task<IActionResult> Edit(int id)
        {
            ViewBag.Brands = await Service.GetBrandsAsync(); ;
            return await base.Edit(id);
        }
    }
}

using Fluent.Architecture.Controllers;
using Fluent.Architecture.Core.Specifications;
using Fluent.Architecture.Entities;
using Fluent.Architecture.Extensions;
using Microsoft.AspNetCore.Mvc;
using MVCWebSite.product_scope;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MVCWebSite.Controllers
{
    public class ProductController : FluentController<Product>
    {
        public new ProductService Service => base.Service.FluentCast<ProductService>();

        [HttpGet]
        [Description("Get a paged list of products")]
        public virtual async Task<IActionResult> List(int itemsPerPage, int currentPage)
        {
            var pagination = new FluentPagination(currentPage, true, itemsPerPage);
            var spec = CreateSpec<FluentAllSpec<Product>>().SetParameter(isList: true);
            var list = await Service.ListAsync(spec, pagination);
            ViewBag.pagination = pagination;
            return View(list);
        }

        [HttpGet]
        [Description("Add a product")]
        public virtual async Task<IActionResult> NewAsync()
        {
            ViewBag.Brands = await Service.GetBrandsAsync();
            return View();
        }

        [HttpPost]
        [Description("Add a product")]
        public virtual async Task<IActionResult> Add([FromForm] Product value)
        {
            await Service.AddAsync(value);
            return RedirectToAction(nameof(List));
        }
    }
}

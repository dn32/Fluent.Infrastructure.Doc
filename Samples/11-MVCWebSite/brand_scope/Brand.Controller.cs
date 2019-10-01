using Fluent.Architecture.Controllers;
using Fluent.Architecture.Core.Specifications;
using Fluent.Architecture.Entities;
using Microsoft.AspNetCore.Mvc;
using MVCWebSite.brand_scope;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MVCWebSite.Controllers
{
    public class BrandController : FluentController<Brand>
    {
        [HttpGet]
        [Description("Get a paged list of brands")]
        public virtual async Task<IActionResult> List(int itemsPerPage,int currentPage)
        {
            var pagination = new FluentPagination(currentPage, true, itemsPerPage);
            var spec = CreateSpec<FluentAllSpec<Brand>>().SetParameter(isList: true);
            var list = await Service.ListAsync(spec, pagination);
            ViewBag.pagination = pagination;
            return View(list);
        }

        [HttpGet]
        [Description("Add a brand")]
        public virtual IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Description("Add a brand")]
        public virtual async Task<IActionResult> Add([FromForm] Brand value)
        {
            await Service.AddAsync(value);
            return RedirectToAction(nameof(List));
        }
    }
}

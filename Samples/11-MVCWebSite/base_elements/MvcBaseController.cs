using Fluent.Architecture.Controllers;
using Fluent.Architecture.Core.Specifications;
using Fluent.Architecture.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MVCWebSite.base_elements
{
    public class MvcBaseController<T> : FluentController<T> where T : MvcBaseEntity, new()
    {
        [HttpGet]
        [Description("Get a paged list of item")]
        public virtual async Task<IActionResult> List(int itemsPerPage, int currentPage)
        {
            var pagination = new FluentPagination(currentPage, true, itemsPerPage);
            var spec = CreateSpec<FluentAllSpec<T>>().SetParameter(isList: true);
            var list = await Service.ListAsync(spec, pagination);
            ViewBag.pagination = pagination;
            return View(list);
        }

        [HttpGet]
        [Description("Add a item")]
        public virtual IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Description("Add a item")]
        public virtual async Task<IActionResult> Add([FromForm] T value)
        {
            await Service.AddAsync(value);
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        [Description("Update a product")]
        public virtual async Task<IActionResult> Update([FromForm] T value)
        {
            await Service.UpdateAsync(value);
            return RedirectToAction(nameof(List));
        }

        [HttpGet("[Controller]/[Action]/{Id}")]
        [Description("Delete a product")]
        public virtual async Task<IActionResult> Edit(int id)
        {
            var entity = await Service.FindAsync(new T { Id = id }); ;
            return View(entity);
        }

        [HttpGet("[Controller]/[Action]/{Id}")]
        [Description("Delete a product")]
        public virtual async Task<IActionResult> Remove(int id)
        {
            await Service.RemoveAsync(new T { Id = id });
            return RedirectToAction(nameof(List));
        }
    }
}

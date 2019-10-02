using MVCWebSite.base_elements;
using MVCWebSite.brand_scope;

namespace MVCWebSite.Controllers
{
    public class BrandController : MvcBaseController<Brand>
    {
        //[HttpGet]
        //[Description("Get a paged list of brands")]
        //public virtual async Task<IActionResult> List(int itemsPerPage, int currentPage)
        //{
        //    var pagination = new FluentPagination(currentPage, true, itemsPerPage);
        //    var spec = CreateSpec<FluentAllSpec<Brand>>().SetParameter(isList: true);
        //    var list = await Service.ListAsync(spec, pagination);
        //    ViewBag.pagination = pagination;
        //    return View(list);
        //}

        //[HttpGet]
        //[Description("Add a brand")]
        //public virtual IActionResult New()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[Description("Add a brand")]
        //public virtual async Task<IActionResult> Add([FromForm] Brand value)
        //{
        //    await Service.AddAsync(value);
        //    return RedirectToAction(nameof(List));
        //}

        //[HttpPost]
        //[Description("Updayte a brand")]
        //public virtual async Task<IActionResult> Update([FromForm] Brand value)
        //{
        //    await Service.UpdateAsync(value);
        //    return RedirectToAction(nameof(List));
        //}

        //[HttpGet("[Controller]/[Action]/{Id}")]
        //[Description("Delete a brand")]
        //public virtual async Task<IActionResult> Edit(int id)
        //{
        //    var entity = await Service.FindAsync(new Brand { Id = id });
        //    return View(entity);
        //}

        //[HttpGet("[Controller]/[Action]/{Id}")]
        //[Description("Delete a brand")]
        //public virtual async Task<IActionResult> Remove(int id)
        //{
        //    await Service.RemoveAsync(new Brand { Id = id });
        //    return RedirectToAction(nameof(List));
        //}
    }
}

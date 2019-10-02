using Fluent.Architecture.Extensions;
using Microsoft.AspNetCore.Mvc;
using MVCWebSite.base_elements;
using System.Threading.Tasks;

namespace MVCWebSite.product_scope
{
    public class SaleController : MvcBaseController<Sale>
    {
        public new SaleService Service => base.Service.FluentCast<SaleService>();

        public async Task<IActionResult> FinalizeSale(int id)
        {
            await Service.FinalizeSale(id);
            return View();
        }
    }
}

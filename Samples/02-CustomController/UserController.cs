using Fluent.Architecture.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomController
{
    [Route("/api/[Controller]/[Action]")]
    public class UserController : FluentAPIController<User>
    {
        public IActionResult MyCustomAction()
        {
            return Content("Hello!");
        }

        [NonAction]
        public override async Task<DefaultResult> Truncate([FromHeader] string ERASE_ALL_DATA = "false")
        {
            return await base.Truncate();
        }
    }
}

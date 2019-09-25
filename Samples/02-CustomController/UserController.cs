using Fluent.Architecture.Controllers;
using Microsoft.AspNetCore.Mvc;

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
        public override DefaultResult Truncate([FromHeader] string ERASE_ALL_DATA = "false")
        {
            return base.Truncate(ERASE_ALL_DATA);
        }
    }
}

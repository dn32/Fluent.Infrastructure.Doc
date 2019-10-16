using Fluent.Architecture.Controllers;
using Fluent.Architecture.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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

    /* 3. Example entity */
    public class User : FluentEntity
    {
        [Key]
        public long Code { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
    }
}

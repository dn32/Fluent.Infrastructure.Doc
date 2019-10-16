using Fluent.Architecture.Controllers;
using Fluent.Architecture.Core.Doc.Attributes;
using Fluent.Architecture.Core.Enumerator;
using Fluent.Architecture.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CustomController
{
    [FluentDoc(Display = EnumFluentDisplay.Hidden)]
    [Route("/api/[Controller]/[Action]")]
    public class NotDocController : FluentController<NotDocControllerEntity>
    {
        public IActionResult MyCustomAction()
        {
            return Content("Hello!");
        }
    }

    public class NotDocControllerEntity : FluentEntity
    {
        [Key]
        public long Code { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
    }
}

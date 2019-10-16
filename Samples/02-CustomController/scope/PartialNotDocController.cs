using Fluent.Architecture.Controllers;
using Fluent.Architecture.Core.Doc.Attributes;
using Fluent.Architecture.Core.Enumerator;
using Fluent.Architecture.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CustomController
{
    [Route("/api/[Controller]/[Action]")]
    public class PartialNotDocController : FluentController<PartialNotDocEntity>
    {
        public IActionResult MyCustomAction()
        {
            return Content("Hello!");
        }

        [FluentDoc(Display = EnumFluentDisplay.Hidden)]
        public IActionResult MyHiddeCustomAction()
        {
            return Content("Hello!");
        }
    }

    public class PartialNotDocEntity : FluentEntity
    {
        [Key]
        public long Code { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
    }
}

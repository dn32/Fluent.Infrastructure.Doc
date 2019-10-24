using Fluent.Architecture.Controllers;
using Fluent.Architecture.Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Composition.Entities
{
    [Microsoft.AspNetCore.Mvc.Route("/api/[Controller]/[Action]")]
    public class UserController : FluentAPIController<User>
    {
        [HttpGet]
        public async Task<List<object>> GetCustom([FromQuery] string fields)
        {
            if (fields is null) { throw new ArgumentNullException(nameof(fields)); }

            var properties = fields.Split(",");
            var spec = CreateSpec<FluentDynamicSpec<User>>().SetParameters(properties, true);
            var list = await Service.ListSelectAsync(spec);
            return list;
        }
    }
}
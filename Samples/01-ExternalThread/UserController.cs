using Fluent.Architecture.Controllers;
using Microsoft.AspNetCore.Mvc;
using SimpleHelloWorld;
using System.Threading.Tasks;

namespace ExternalThread
{
    [Route("[Controller]/[Action]")]
    public class UserController : FluentController<User>
    {
        [HttpGet]
        public async Task<DefaultResult> StartOperation()
        {
            _ = new TaskFactory().StartNew(Opoeration.Start, HttpContext);
            return await ResultAsync("StartOperation sucessfull");
        }
    }
}

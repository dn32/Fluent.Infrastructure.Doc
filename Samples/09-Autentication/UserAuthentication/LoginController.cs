using Fluent.Architecture.Controllers;
using Fluent.Architecture.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.UserAuthentication
{
    [Route("/api/Login/[Action]")]
    public class LoginController : FluentServiceController<AuthenticationService>
    {
        //http://localhost:5000/api/Login/GetToken?name=admin&email=test@test.com.br
        [AllowAnonymous]
        [HttpGet]
        public async Task<string> GetToken(FluentAuthenticationUser user)
        {
            return await Service.LoginAsync(user);
        }

        //http://localhost:5000/api/Login/GetClientId?Authorization=[token]
        [HttpGet]
        public string GetClientId()
        {
            return HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("client-id")).Value;
        }
    }
}

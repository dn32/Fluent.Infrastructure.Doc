using Fluent.Architecture.Controllers;
using Fluent.Architecture.Core.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.UserAuthentication
{
    public class LoginController : FluentServiceController<AuthenticationService>
    {
        [AllowAnonymous]
        public async Task<string> Login(FluentAuthenticationUser user)
        {
            return await Service.LoginAsync(user);
        }

        public void TestAction()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Email")).Value;
        }
    }
}

using Fluent.Architecture.Core.Models;
using Fluent.Architecture.Core.Services;
using Fluent.Architecture.Services;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authentication.UserAuthentication
{
    public class AuthenticationService : FluentAuthenticationService
    {
        protected virtual FluentService<User> UserService => null;

        public override async Task<(bool sucess, List<Claim> claims)> AuthenticateAsync(FluentAuthenticationUser user)
        {
            var spec = CreateSpec<UserAndPswSpec>().AddParameters(user.Email, user.Password);
            var sucess = await UserService.ExistsAsync(spec);
            var claims = new List<Claim>()
            {
                new Claim("client-id", "123")
            };

            return (sucess, claims);
        }

        public override void Register(FluentAuthenticationUser fluentAuthenticationUser)
        {
            base.Register(fluentAuthenticationUser);
        }
    }
}

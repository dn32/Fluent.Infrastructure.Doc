using Fluent.Architecture.Core.Models;
using Fluent.Architecture.Core.Services;
using Fluent.Architecture.Services;
using System.Threading.Tasks;

namespace Migrations
{
    public class AuthenticationService : FluentAuthenticationService
    {
        protected virtual FluentService<User> UserService => null;

        public override async Task<bool> AuthenticateAsync(FluentAuthenticationUser user)
        {
            var spec = CreateSpec<UserAndPswSpec>().AddParameters(user.Email, user.Password);
            return await UserService.ExistsAsync(spec);
        }

        public override void Register(FluentAuthenticationUser fluentAuthenticationUser)
        {
            base.Register(fluentAuthenticationUser);
        }
    }
}

using Fluent.Architecture.Core.Services;

namespace Composition
{
    public class CustomAuthenticationService : FluentAuthenticationService
    {
        public override bool InternalLogin(string user, string psw)
        {
            return true;
        }

        public override string Login(string user, string psw)
        {
            return base.Login(user, psw);
        }

    }
}

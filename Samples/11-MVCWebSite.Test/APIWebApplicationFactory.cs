using Microsoft.AspNetCore.Mvc.Testing;

namespace MVCWebSite.Test
{
    public class APIWebApplicationFactory : WebApplicationFactory<MVCWebSite.Startup>
    {
        public APIWebApplicationFactory()
        {

        }
    }
}
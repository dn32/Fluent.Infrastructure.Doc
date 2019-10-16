using Fluent.Architecture.Factory;
using Fluent.Architecture.Services;
using SimpleHelloWorld;
using System.Threading.Tasks;

namespace ExternalThread
{
    public class Opoeration
    {
        public static void Start(object httpContext)
        {
            Task.Delay(5000).Wait();
            var service = ServiceFactory.Create<FluentService<User>>(httpContext, "Teste de operação");
            service.AddAsync(new User { Email = "mail@test.com", Name = "My name" });
        }
    }
}

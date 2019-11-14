using Fluent.Architecture;
using Fluent.Architecture.EntityFramework;
using Fluent.Architecture.EntityFramework.SqLite;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SimpleHelloWorld
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

            /* 1. Startup Architecture */
            services
                .AddMvc()
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
                .AddFluentArchitecture(jsonSerializerSettings)
                .UseEntityFramework()
                .AddConnectionString("Data Source=SimpleHelloWorld.db;", createDatabaseIfNotExists: true, typeof(EfContextSqLite))
                .Build()
                .AddFluentDoc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            /* 2. Use Architecture documentation */
            app.UseFluentDoc();
        }
    }
}

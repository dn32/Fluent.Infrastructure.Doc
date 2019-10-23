using Authentication.UserAuthentication;
using Fluent.Architecture;
using Fluent.Architecture.EntityFramework;
using Fluent.Architecture.EntityFramework.SqLite;
using Fluent.Architecture.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Authentication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var jwtInfo = new FluentJwtInfo
            {
                Audience = "Fluent",
                Issuer = "Fluent",
                SecretKey = "My Secret Key here" // Todo - Attention! Change it
            };

            /* 1. Startup Architecture */
            services
                .AddMvc(options =>
                {
                    options.Filters.Add(new FluentAuthorizationFilter());
                })
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
                .AddFluentArchitecture(jsonSerializerSettings)
                .UseEntityFramework()
                .AddConnectionString("Data Source=Migrations.db;", createDatabaseIfNotExists: true, typeof(EfContextSqLite))
                .UseJwt<AuthenticationService>(jwtInfo)
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

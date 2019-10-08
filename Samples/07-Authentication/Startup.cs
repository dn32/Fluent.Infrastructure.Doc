using Fluent.Architecture;
using Fluent.Architecture.EntityFramework;
using Fluent.Architecture.EntityFramework.SqLite;
using Fluent.Architecture.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Composition
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var jwtInfo = new FluentJwtInfo
            {
                Audience = "07_Authentication",
                Issuer = "07_Authentication",
                SecretKey = "My private key" //Todo - Attention! This key must be changed!
            };

#if RELEASE
            if (jwtInfo.SecretKey == "My private key") throw new InvalidOperationException("Attention! This key must be changed!");
#endif

            /* 1. Startup Architecture */
            services
                .AddMvc()
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
                .AddFluentArchitecture(jsonSerializerSettings)
                .UseJwt<CustomAuthenticationService>(jwtInfo)
                .UseEntityFramework()
                .AddConnectionString("Data Source=Authentication.db;", createDatabaseIfNotExists: true, typeof(EfContextSqLite))
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

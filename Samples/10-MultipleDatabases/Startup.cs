using Fluent.Architecture;
using Fluent.Architecture.Entities;
using Fluent.Architecture.EntityFramework;
using Fluent.Architecture.EntityFramework.SqLite;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MultipleDatabases
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
                .AddConnectionString("Data Source=tanant_db.db;", createDatabaseIfNotExists: true, typeof(EfContextSqLite), "tanant_db")
                .AddConnectionString(GetTenantDB, createDatabaseIfNotExists: true, typeof(EfContextSqLite), "client_db")
                .Build()
                .AddFluentDoc();
        }

        //This method is invoked on every request.
        string GetTenantDB(UserSessionRequest userSessionRequest)
        {
            //Example
            //var tenant_id = userSessionRequest.LocalHttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("tenant_id")).Value;
            //return $"Data Source=client_db{tenant_id}.db;";

            return $"Data Source=client_db.db;";
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

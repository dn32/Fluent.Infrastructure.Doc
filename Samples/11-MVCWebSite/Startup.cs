using Fluent.Architecture;
using Fluent.Architecture.EntityFramework;
using Fluent.Architecture.EntityFramework.SqLite;
using Fluent.Architecture.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCWebSite.base_elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MVCWebSite
{
    public class LocalFluentExceptionHandlerAttribute : FluentExceptionHandlerAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new LocalFluentExceptionHandlerAttribute());
            });

            /* 1. Startup Architecture */
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

            builder
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
                .AddFluentArchitecture(jsonSerializerSettings)
                .SetGenericControllerType(typeof(MvcBaseController<>))
                .UseEntityFramework()
                .AddConnectionString("Data Source=MVCWebSite.db;", createDatabaseIfNotExists: true, typeof(EfContextSqLite))
                .Build()
                .AddFluentDoc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            /* 2. Use Architecture documentation */
            app.UseFluentDoc();
        }
    }
}

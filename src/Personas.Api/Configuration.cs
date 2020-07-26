using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Hellang.Middleware.ProblemDetails;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Personas.Data;
using Personas.Data.Migrations;

namespace Personas.Api
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
        {
            return services
                .AddHttpContextAccessor()
                .AddCustomMvc()
                .AddAuthorization(Policies.Configure)
                .AddCustomProblemDetails(environment)
                .AddCustomConfiguration(configuration)
                .AddCustomApiBehaviour()
                .AddCustomServices();
        }

        public static IApplicationBuilder Configure(
              IApplicationBuilder app,
              Func<IApplicationBuilder, IApplicationBuilder> configureHost, ApplicationInitializer initializer)
        {
            initializer.SeedUsers().Wait();

            return configureHost(app)
                .UseProblemDetails()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                     endpoints.MapControllerRoute(
                         name: "default",
                         pattern: "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}

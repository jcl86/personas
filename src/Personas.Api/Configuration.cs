using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Hellang.Middleware.ProblemDetails;
using System;
using Microsoft.AspNetCore.Http;

namespace Personas.Api
{
    public static class Configuration
    {
        public const string ApiPrefix = "api";
        public static IServiceCollection ConfigureServices(IServiceCollection services, IWebHostEnvironment environment)
        {
            return services
                .AddHttpContextAccessor()
                .AddCustomMvc()
                .AddAuthorization()
                .AddCustomProblemDetails(environment)
                .AddCustomApiBehaviour()
                .AddCustomServices();
        }

        public static IApplicationBuilder Configure(
              IApplicationBuilder app,
              Func<IApplicationBuilder, IApplicationBuilder> configureHost)
        {
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
                    endpoints.MapGet("/", async context =>
                    {
                        await context.Response.WriteAsync($"Welcome to Personas API from {Environment.MachineName}");
                    });
                });
        }
    }
}

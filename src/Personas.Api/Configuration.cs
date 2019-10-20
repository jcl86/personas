using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Hellang.Middleware.ProblemDetails;
using System;

namespace Personas.Api
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IHostingEnvironment environment)
        {
            return services
                .AddHttpContextAccessor()
                .AddCustomMvc()
                .AddCustomProblemDetails(environment)
                .AddCustomApiBehaviour()
                .AddCustomServices();
        }

        public static IApplicationBuilder Configure(
              IApplicationBuilder app,
              Func<IApplicationBuilder, IApplicationBuilder> configureHost)
        {
            return configureHost(app)
                .UseProblemDetails();
        }
    }
}

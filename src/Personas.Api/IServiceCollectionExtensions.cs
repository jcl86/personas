using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Hellang.Middleware.ProblemDetails;
using Personas.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Personas.Api
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services) =>
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddApplicationPart(typeof(IServiceCollectionExtensions).Assembly)
                .Services;


        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<IRandomProvider, RandomProvider>();
            return services;
        }

        public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services, IHostingEnvironment environment)
        {
            return services
                .AddProblemDetails(configure =>
                {
                    configure.IncludeExceptionDetails = _ => environment.EnvironmentName == "Development";
                });
        }

        public static IServiceCollection AddCustomApiBehaviour(this IServiceCollection services)
        {
            return services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = false;
                options.SuppressInferBindingSourcesForParameters = false;

                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Instance = context.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest,
                        Type = $"https://httpstatuses.com/400",
                        Detail = "Please refer to the errors property for additional details."
                    };
                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes =
                        {
                            "application/problem+json",
                            "application/problem+xml"
                        }
                    };
                };
            });
        }
    }
}

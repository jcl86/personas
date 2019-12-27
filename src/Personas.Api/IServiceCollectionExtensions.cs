using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Hellang.Middleware.ProblemDetails;
using Personas.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personas.Data.Repositories;
using System;

namespace Personas.Api
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services) =>
            services
                .AddControllers()
                .AddApplicationPart(typeof(IServiceCollectionExtensions).Assembly)
                .Services;


        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<System.Random>();
            services.AddScoped<IRandomProvider, RandomProvider>();
            services.AddScoped<INombresRepository, NombresRepository>();
            services.AddScoped<IApellidosRepository, ApellidosRepository>();
            services.AddScoped<ILugaresRepository, LugaresRepository>();
            services.AddScoped<IDatesProvider, DatesProvider>();
            services.AddScoped<IPersonasService, PersonasService>();
            return services;
        }

        public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services, IWebHostEnvironment environment)
        {
            return services
                .AddProblemDetails(configure =>
                {
                    configure.IncludeExceptionDetails = _ => environment.EnvironmentName == "Development";
                    configure.Map<QuantityUnderHundredException>(exception => new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace,
                        Status = StatusCodes.Status400BadRequest,
                        Type = nameof(QuantityUnderHundredException)
                    });
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

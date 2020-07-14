using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Hellang.Middleware.ProblemDetails;
using Personas.Domain;
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
            services.AddScoped<Random>();
            services.AddScoped<IRandomProvider, RandomProvider>();
            services.AddScoped<INombresRepository, NombresRepository>();
            services.AddScoped<IApellidosRepository, ApellidosRepository>();
            services.AddScoped<ILugaresRepository, LugaresRepository>();
            services.AddScoped<IDatesProvider, DatesProvider>();
            services.AddScoped<IPersonasService, PeopleSearcher>();
            return services;
        }

        public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services, IWebHostEnvironment environment)
        {
            return services
                .AddProblemDetails(configure =>
                {
                    configure.IncludeExceptionDetails = (ctx, exception) => environment.EnvironmentName == "Development";
                    configure.Map<UnauthorizedAccessException>(exception => new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace,
                        Status = StatusCodes.Status401Unauthorized,
                        Type = nameof(UnauthorizedAccessException)
                    });
                    configure.Map<AccessForbidenException>(exception => new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace,
                        Status = StatusCodes.Status403Forbidden,
                        Type = nameof(AccessForbidenException)
                    });
                    configure.Map<QuantityUnderHundredException>(exception => new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace,
                        Status = StatusCodes.Status400BadRequest,
                        Type = nameof(QuantityUnderHundredException)
                    });
                    configure.Map<ConversionException>(exception => new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace,
                        Status = StatusCodes.Status404NotFound,
                        Type = nameof(ConversionException)
                    });
                    configure.Map<DomainException>(exception => new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace,
                        Status = StatusCodes.Status400BadRequest,
                        Type = nameof(DomainException)
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

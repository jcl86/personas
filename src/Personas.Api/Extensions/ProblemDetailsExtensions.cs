using Microsoft.AspNetCore.Hosting;
using Hellang.Middleware.ProblemDetails;
using Personas.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProblemDetailsExtensions
    {
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
                    configure.Map<NotFoundException>(exception => new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace,
                        Status = StatusCodes.Status404NotFound,
                        Type = nameof(NotFoundException)
                    });
                    configure.Map<DomainException>(exception => new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace,
                        Status = StatusCodes.Status400BadRequest,
                        Type = nameof(DomainException)
                    });
                    configure.Map<Exception>(exception => new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace,
                        Status = StatusCodes.Status500InternalServerError,
                        Type = nameof(Exception)
                    });
                });
        }
    }
}

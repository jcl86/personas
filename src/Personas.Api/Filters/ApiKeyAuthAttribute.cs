using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Personas.Core;

namespace Personas.Api
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        public const string ApiKeyConfigurationName = "ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            string apiKeyValue = configuration.GetValue<string>(key: ApiKeyConfigurationName);
            if (apiKeyValue == null)
            {
                throw new AuthorizationDisabledException();
            }

            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyConfigurationName, out var potentialApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!apiKeyValue.Equals(potentialApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}

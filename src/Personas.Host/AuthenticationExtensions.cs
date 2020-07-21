using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Personas.Domain;

namespace Personas.Host
{
    public static class AuthenticationExtensions
    {
        public const string ApiKeyConfigurationName = "ApiKey";

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            string apiKeyValue = configuration.GetValue<string>(key: ApiKeyConfigurationName);

            var key = Encoding.ASCII.GetBytes(apiKeyValue);
            services.AddAuthentication(x =>
            {
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userRepository = context.HttpContext.RequestServices.GetRequiredService<IPasswordChanger>();
                        var userId = Guid.Parse(context.Principal.Identity.Name);
                        var user = userRepository.GetUserById(userId);
                        if (user == null)
                        {
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                options.RequireHttpsMetadata = environment.EnvironmentName == "Development";
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            return services;
        }
    }
}

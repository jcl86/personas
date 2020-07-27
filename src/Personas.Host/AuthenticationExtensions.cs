using System;
using System.Linq;
using System.Security.Claims;
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
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            string apiKeyValue = configuration.GetValue<string>(key: Api.TokenGenerator.ApiKeyConfigurationName);

            var key = Encoding.ASCII.GetBytes(apiKeyValue);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = async context =>
                        {
                            var userRepository = context.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
                            var userId = Guid.Parse(context.Principal.Identity.Name);
                            var user = await userRepository.GetUser(userId);

                            if (user == null)
                            {
                                context.Fail("Unauthorized");
                            }
                          //  context.Principal.AddIdentity(new ClaimsIdentity(user.Roles.Select(x => new Claim(ClaimsIdentity.DefaultRoleClaimType, x))));
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

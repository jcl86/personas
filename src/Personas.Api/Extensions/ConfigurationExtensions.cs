using Microsoft.Extensions.Configuration;
using Personas.Data;
using Microsoft.Extensions.Options;
using Personas.Domain;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailConfiguration>(configuration.GetSection("MailConfiguration"));
            services.AddScoped(x => x.GetRequiredService<IOptionsSnapshot<MailConfiguration>>().Value);

            services.Configure<SendGridCredentials>(configuration.GetSection("MailConfiguration:SendGridCredentials"));
            services.AddScoped(x => x.GetRequiredService<IOptionsSnapshot<SendGridCredentials>>().Value);

            services.Configure<UsersConfiguration>(configuration.GetSection("UsersConfiguration"));
            services.AddScoped(x => x.GetRequiredService<IOptionsSnapshot<UsersConfiguration>>().Value);

            services.Configure<DefaultAdministrator>(configuration.GetSection("UsersConfiguration:DefaultAdministrator"));
            services.AddScoped(x => x.GetRequiredService<IOptionsSnapshot<DefaultAdministrator>>().Value);

            return services;
        }
    }
}

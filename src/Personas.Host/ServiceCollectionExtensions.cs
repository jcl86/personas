using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Personas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;

namespace Personas.Host
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlite(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(configuration.GetValue<string>("ConnectionString:Sqlite"));
            });
            services.AddCustomIdentityOptions();
            return services;
        }
    }
}

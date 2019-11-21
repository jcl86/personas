using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Personas.Data;
using Microsoft.EntityFrameworkCore;

namespace Personas.Host
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlite(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(configuration.GetValue<string>("ConnectionString:Sqlite"));
            });
        }
    }
}

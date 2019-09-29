using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Personas.Host
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkCore(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });
    }

    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Api.Configuration.ConfigureServices(services, Environment)
           .AddEntityFrameworkCore(Configuration)
           .AddCustomAuthentication()
           .AddCustomAuthorization()
           .AddCustomHealthChecks()
           .AddHostingDiagnosticHandler();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app)
        {
            Api.Configuration.Configure(app, host =>
            {
                return host
                    .UseDefaultFiles()
                    .UseStaticFiles()
            });
        }
    }
}

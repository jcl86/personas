using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Personas.Api;
using Personas.Data;
using Acheve.AspNetCore.TestHost.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.TestHost;
using Acheve.TestHost;

namespace Personas.FunctionalTests
{
    public class TestStartup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment environment;

        public TestStartup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.ConfigureServices(services, environment)
                .AddDbContext<DataContext>(setup =>
                {
                    setup.UseSqlite(configuration.GetValue<string>("ConnectionString:Sqlite"));
                })
                .AddCustomIdentityOptions()
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = TestServerDefaults.AuthenticationScheme;
                })
                .AddTestServer();
        }

        public void Configure(IApplicationBuilder app)
        {
            Configuration.Configure(app, host => host);
        }
    }
}

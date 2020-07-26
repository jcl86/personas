using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.Extensions.DependencyInjection;

namespace Personas.FunctionalTests
{
    public class ServerFixture
    {
        public IConfiguration Configuration { get; set; }
        public TestServer Server { get; private set; }

        public ServerFixture()
        {
            var host = new HostBuilder()
               .ConfigureWebHost(webBuilder =>
               {
                   webBuilder.UseTestServer()
                    .UseStartup<TestStartup>()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .ConfigureAppConfiguration(app =>
                    {
                        app.AddJsonFile("appsettings.json", optional: true);
                        app.AddUserSecrets("6a2901b4-1d39-47c9-a49b-d20cc7637e6b");
                        app.AddEnvironmentVariables();
                    });
            })
            .Start();

            Server = host.GetTestServer();
            Configuration = Server.Services.GetService<IConfiguration>();
        }
    }
}

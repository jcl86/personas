using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Personas.FunctionalTests
{
    public class ServerFixture
    {
        public TestServer Server { get; private set; }

        public ServerFixture()
        {
            var host = new HostBuilder()
            .ConfigureWebHost(webBuilder =>
            {
                webBuilder
                    .UseTestServer()
                    .UseStartup<TestStartup>()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .ConfigureAppConfiguration(app =>
                    {
                        app.AddJsonFile("appsettings.json", optional: true);
                        app.AddEnvironmentVariables();
                    });
            })
            .Start();

            Server = host.GetTestServer();

            host.StartAsync().Wait();

            Server = host.GetTestServer();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Personas.Data;

namespace Personas.Host
{
    public class Startup
    {
        private readonly IWebHostEnvironment environment;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Api.Configuration.ConfigureServices(services, environment, Configuration)
             .AddSqlite(Configuration)
             .AddCustomAuthentication(Configuration, environment)
             .AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1", new OpenApiInfo 
                  { 
                      Title = "Personas API", 
                      Version = "v1",
                      Description = "Api que permite obtener datos de personas aleatorios",
                      Contact = new OpenApiContact
                      {
                          Name = "jcl",
                          Url = new Uri("https://github.com/jcl86"),
                      },
                      License = new OpenApiLicense
                      {
                          Name = "MIT License",
                          Url = new Uri("https://opensource.org/licenses/MIT"),
                      }
                  });
                  var xmlFile = $"{typeof(Api.Configuration).Assembly.GetName().Name}.xml";
                  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                  c.IncludeXmlComments(xmlPath);
              });
        }

        public void Configure(IApplicationBuilder app, ApplicationInitializer initializer)
        {
            Api.Configuration.Configure(app, host =>
            {
                return host
                    .UseDefaultFiles()
                    .UseStaticFiles()
                    .UseSwagger()
                    .UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Personas V1");
                        c.RoutePrefix = "";
                    });
            }, initializer);
        }
    }
}

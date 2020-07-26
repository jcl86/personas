using Microsoft.Extensions.DependencyInjection;
using Personas.Domain;
using Personas.Data.Repositories;
using System;
using Personas.Application;
using Microsoft.AspNetCore.Identity;
using Personas.Api;
using Personas.Data;
using Personas.Infraestructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services) =>
            services
                .AddControllers()
                .AddApplicationPart(typeof(ServiceCollectionExtensions).Assembly)
                .Services;

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<Random>();
            services.AddScoped<RandomProvider>();
            services.AddScoped<INamesRepository, NamesRepository>();
            services.AddScoped<ISurnamesRepository, SurnamesRepository>();
            services.AddScoped<IPlacesRepository, PlacesRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserSignIn, UserSignIn>();
            services.AddScoped<IDateProvider, DateProvider>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<ApplicationInitializer>();
            services.AddScoped<SuscribersNotifier>();
            services.AddScoped<PeopleSearcher>();
            services.AddScoped<NameSearcher>();
            services.AddScoped<SurnameSearcher>();
            services.AddScoped<PlaceSearcher>();
            services.AddScoped<LoginService>();
            services.AddScoped<RegisterService>();
            services.AddScoped<PasswordChanger>();
            services.AddScoped<UserFinder>();
            services.AddScoped<UserEraser>();
            return services;
        }
    }


}

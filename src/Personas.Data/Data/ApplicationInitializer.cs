using Microsoft.AspNetCore.Identity;
using Personas.Domain;
using System;
using System.Threading.Tasks;

namespace Personas.Data
{
    public class ApplicationInitializer
    {
        private readonly UserManager<User> userManager;
        private readonly DefaultAdministrator defaultAdministrator;

        public ApplicationInitializer(UserManager<Data.User> userManager, DefaultAdministrator defaultAdministrator)
        {
            this.userManager = userManager;
            this.defaultAdministrator = defaultAdministrator;
        }

        public async Task SeedUsers()
        {
            if (defaultAdministrator is null || defaultAdministrator.Username.IsEmpty())
            {
                throw new DomainException("Default administrator must have a value");
            }

            if ((await userManager.FindByEmailAsync(defaultAdministrator.Username)) is null)
            {
                var user = new User
                {
                    UserName = defaultAdministrator.Username,
                    Email = defaultAdministrator.Username
                };

                var result = await userManager.CreateAsync(user, defaultAdministrator.Password);

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Data.Roles.Administrator).Wait();
                }
            }
        }
    }
}

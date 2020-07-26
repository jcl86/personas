using Microsoft.AspNetCore.Identity;
using Personas.Domain;
using System;
using System.Threading.Tasks;

namespace Personas.Data
{
    public class ApplicationInitializer
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly DefaultAdministrator defaultAdministrator;

        public ApplicationInitializer(UserManager<Data.User> userManager, RoleManager<IdentityRole> roleManager, DefaultAdministrator defaultAdministrator)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
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
                await roleManager.CreateAsync(new IdentityRole { Name = Data.Roles.Administrator, NormalizedName = Data.Roles.Administrator.ToUpper() });

                var user = new User
                {
                    UserName = defaultAdministrator.Username,
                    Email = defaultAdministrator.Username
                };

                var result = await userManager.CreateAsync(user, defaultAdministrator.Password);

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Roles.Administrator).Wait();
                }
            }
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Personas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Api
{
    public class UserCommands : IUserCommands
    {
        private readonly UserManager<Data.User> userManager;

        public UserCommands(UserManager<Data.User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task Create(UserName email, string password)
        {
            var newUser = new Data.User() { UserName = email.ToString(), Email = email.ToString() };

            var result = await userManager.CreateAsync(newUser, password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                throw new RegistrationException(email, errors.ToArray());
            }
        }

        public async Task UpdatePassword(User user, string currentPassword, string newPassword)
        {
            var databaseUser = await userManager.FindByIdAsync(user.Id.ToString());
            var result = await userManager.ChangePasswordAsync(databaseUser, currentPassword, newPassword);
            if (!result.Succeeded)
            {
                throw new DomainException(result.Errors.Select(x => x.Description));
            }
        }

        public async Task DeleteUser(Guid idUser)
        {
            var user = await userManager.FindByIdAsync(idUser.ToString());
            await userManager.DeleteAsync(user);
        }
    }

  
}

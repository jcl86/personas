using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Personas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Api
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<Data.User> userManager;

        public UserRepository(UserManager<Data.User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await userManager.Users.ToListAsync();
            return users.Select(x => Map(x)).ToList();
        }

        public async Task<User> GetUser(Guid idUser)
        {
            var user = await userManager.FindByIdAsync(idUser.ToString());
            if (user is null)
            {
                return null;
            }
            return Map(user);
        }

        public async Task<User> GetUser(UserName email)
        {
            var user = await userManager.FindByEmailAsync(email.ToString());
            if (user is null)
            {
                return null;
            }
            return Map(user);
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

        private User Map(Data.User user) => new User(user.Id, user.UserName);
    }
}

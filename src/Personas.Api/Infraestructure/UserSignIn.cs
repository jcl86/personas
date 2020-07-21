using Microsoft.AspNetCore.Identity;
using Personas.Domain;
using System;
using System.Collections.Generic;
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

        public async Task<User> GetUserById(Guid idUser)
        {
            var user = await userManager.FindByIdAsync(idUser.ToString());
            return Map(user);
        }

        public async Task UpdatePassword(Guid idUser, string currentPassword, string newPassword)
        {
            var user = await userManager.FindByIdAsync(idUser.ToString());
            var result = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (result.)
        }

        public Task DeleteUser(Guid idUser)
        {
            userManager.DeleteAsync();
        }

        private User Map(Data.User user) => new User(user.Id, user.UserName);
    }
    public class UserSignIn : IUserSignIn
    {
        private readonly SignInManager<Data.User> signInManager;

        public UserSignIn(SignInManager<Data.User> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task SignIn(string username, string password)
        {
            var result = await signInManager.PasswordSignInAsync(username, password, false, false);
            if (!result.Succeeded)
            {
                throw new UnauthorizedAccessException("Usuario o contraseña incorrectos");
            }
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Personas.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personas.Api
{
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

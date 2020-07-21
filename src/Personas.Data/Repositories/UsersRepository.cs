using Microsoft.AspNetCore.Identity;
using Personas.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personas.Data.Repositories
{
    public class UsersRepository : Repository, IPasswordChanger
    {
        private UserManager<User> userManager;

        public UsersRepository(DataContext context, UserManager<User> userManager) : base(context)
        {
            this.userManager = userManager;
        }

        public async Task<User> CreateUser(string user, string password)
        {
           

            return result.
        }

        public Task DeleteUser(Guid idUser)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await context.Users.FindAsync(id);
            return user;
        }

        public async Task<User> UpdatePassword(Guid idUser, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserAlreadyExists(string username)
        {
            throw new NotImplementedException();
        }
    }


}

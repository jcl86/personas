using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class UserFinder
    {
        private readonly IUserRepository repository;

        public UserFinder(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<User>> FindAll()
        {
            var users = await repository.GetAll();
            return users;
        }

        public async Task<User> Find(Guid id)
        {
            var user = await repository.GetUser(id);
            
            if (user is null)
            {
                throw new NotFoundException($"User with id {id} was not found");
            }

            return user;
        }

        public async Task<User> FindByEmail(string email)
        {
            var user = await repository.GetUser(new UserName(email));

            if (user is null)
            {
                throw new NotFoundException($"User with email {email ?? ""} was not found");
            }

            return user;
        }
    }
}

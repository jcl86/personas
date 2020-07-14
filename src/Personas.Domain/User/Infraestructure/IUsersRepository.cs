using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public interface IUsersRepository
    {
        Task<User> GetUserById(Guid id);
        Task<User> GetUser(string username, string password);
        Task<bool> UserAlreadyExists(string username);

        Task<IEnumerable<User>> GetAll();
        Task<User> CreateUser(string user, string password);
        Task<User> UpdatePassword(Guid idUser, string newPassword);
        Task DeleteUser(Guid idUser);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUser(Guid idUser);
        Task<User> GetUser(UserName email);
    }
}

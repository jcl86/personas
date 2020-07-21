using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public interface IUserRepository
    {
        Task<User> GetUserById(Guid id);
    }
}

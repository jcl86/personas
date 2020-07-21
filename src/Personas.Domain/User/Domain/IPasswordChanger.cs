using System;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public interface IPasswordChanger
    {
        Task<User> UpdatePassword(Guid idUser, string newPassword);
    }
}
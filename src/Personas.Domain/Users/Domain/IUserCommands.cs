using System;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public interface IUserCommands
    {
        Task Create(UserName email, string password);
        Task UpdatePassword(User user, string currentPassword, string newPassword);
        Task DeleteUser(Guid idUser);
    }
}

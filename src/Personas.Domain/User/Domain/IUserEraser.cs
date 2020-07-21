using System;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public interface IUserEraser
    {
        Task DeleteUser(Guid idUser);
    }
}
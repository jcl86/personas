using System.Threading.Tasks;

namespace Personas.Domain
{
    public interface IUserCreator
    {
        Task Create(string email, string password);
    }
}
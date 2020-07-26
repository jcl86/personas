using System.Threading.Tasks;

namespace Personas.Domain
{
    public interface IUserSignIn
    {
        Task SignIn(string username, string password);
    }
}

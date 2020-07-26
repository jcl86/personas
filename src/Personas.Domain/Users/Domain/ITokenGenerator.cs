using Personas.Domain;

namespace Personas.Domain
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}
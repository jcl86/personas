using Personas.Shared;
using System;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class LoginService
    {
        private readonly IUsersRepository usersRepository;
        private readonly ITokenGenerator tokenGenerator;

        public LoginService(IUsersRepository usersRepository, ITokenGenerator tokenGenerator)
        {
            this.usersRepository = usersRepository;
            this.tokenGenerator = tokenGenerator;
        }

        public async Task<string> GetAuthenticationToken(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new DomainException("usuario no puede estar vacío");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new DomainException("contraseña no puede estar vacío");
            }

            var user = await usersRepository.GetUser(username, password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Usuario o contraseña incorrectos");
            }

            string token = tokenGenerator.GenerateToken(user);
            return token;
        }
    }
}

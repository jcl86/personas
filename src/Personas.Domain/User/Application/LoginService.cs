using Personas.Shared;
using System;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class LoginService
    {
        private readonly IUserSignIn userSignIn;
        private readonly ITokenGenerator tokenGenerator;

        public LoginService(IUserSignIn userSignIn, ITokenGenerator tokenGenerator)
        {
            this.userSignIn = userSignIn;
            this.tokenGenerator = tokenGenerator;
        }

        public async Task<string> GetAuthenticationToken(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new DomainException("Usuario no puede estar vacío");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new DomainException("Contraseña no puede estar vacía");
            }

            await userSignIn.SignIn(username, password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Usuario o contraseña incorrectos");
            }

            string token = tokenGenerator.GenerateToken(user);
            return token;
        }
    }
}

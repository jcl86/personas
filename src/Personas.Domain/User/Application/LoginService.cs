using Personas.Shared;
using System;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class LoginService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserSignIn userSignIn;
        private readonly ITokenGenerator tokenGenerator;

        public LoginService(IUserRepository userRepository, IUserSignIn userSignIn, ITokenGenerator tokenGenerator)
        {
            this.userRepository = userRepository;
            this.userSignIn = userSignIn;
            this.tokenGenerator = tokenGenerator;
        }

        public async Task<string> GetAuthenticationToken(string email, string password)
        {
            var username = new UserName(email);

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new DomainException("Contraseña no puede estar vacía");
            }

            await userSignIn.SignIn(username.ToString(), password);

            var user = await userRepository.GetUser(username);
            
            string token = tokenGenerator.GenerateToken(user);
            return token;
        }
    }
}

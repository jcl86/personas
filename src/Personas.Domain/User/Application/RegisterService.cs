using System.Threading.Tasks;

namespace Personas.Domain
{
    public class RegisterService
    {
        private readonly IUserRepository userRepository;

        public RegisterService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> CreateUser(string email, string password)
        {
            var username = new UserName(email);

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new RegistrationException(username, "Password can not be empty");
            }

            await userRepository.Create(username, password);

            var createdUser = await userRepository.GetUser(username);
            return createdUser;
        }
    }
}

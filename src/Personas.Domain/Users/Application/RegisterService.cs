using System.ComponentModel;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class RegisterService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserCommands userCommands;
        private readonly SuscribersNotifier notifier;

        public RegisterService(IUserRepository userRepository, IUserCommands userCommands, SuscribersNotifier notifier)
        {
            this.userRepository = userRepository;
            this.userCommands = userCommands;
            this.notifier = notifier;
        }

        public async Task<User> CreateUser(string email, string password)
        {
            var username = new UserName(email);

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new RegistrationException(username, "Password can not be empty");
            }

            await userCommands.Create(username, password);

            var createdUser = await userRepository.GetUser(username);

            await notifier.Notify(NotificationType.UserCreated, $"User {username} was created for Personas api");

            return createdUser;
        }
    }
}

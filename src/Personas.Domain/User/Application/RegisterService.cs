using System.Threading.Tasks;

namespace Personas.Domain
{
    public class RegisterService
    {
        private readonly IUsersRepository usersRepository;

        public RegisterService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<User> Create(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new DomainException("usuario no puede estar vacío");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new DomainException("contraseña no puede estar vacío");
            }

            bool userAlreadyExists = await usersRepository.UserAlreadyExists(username);

            if (userAlreadyExists)
            {
                throw new DomainException($"El usuario {username} ya existe");
            }

            var user = await usersRepository.CreateUser(username, password);
            return user;
        }
    }
}

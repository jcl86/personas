using System.Threading.Tasks;

namespace Personas.Domain
{
    public class RegisterService
    {
        private readonly IUserCreator userCreator;

        public RegisterService(IUserCreator usercreator)
        {
            this.userCreator = usercreator;
        }

        public async Task Create(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new RegistrationException(email, "Usuario no puede estar vacío");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new RegistrationException(email, "Contraseña no puede estar vacío");
            }

            await userCreator.Create(email, password);
        }
    }
}

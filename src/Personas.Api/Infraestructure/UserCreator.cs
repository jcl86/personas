using Microsoft.AspNetCore.Identity;
using Personas.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Api
{
    public class UserCreator : IUserCreator
    {
        private readonly UserManager<Data.User> userManager;

        public UserCreator(UserManager<Data.User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task Create(string email, string password)
        {
            var newUser = new Data.User { UserName = email, Email = email };

            var result = await userManager.CreateAsync(newUser, password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                throw new RegistrationException(email, errors.ToArray());
            }
        }
    }
}

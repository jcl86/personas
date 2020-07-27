using System;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class UserEraser
    {
        private readonly IUserRepository userRepository;
        private readonly IUserCommands userCommands;

        public UserEraser(IUserRepository userRepository, IUserCommands userCommands)
        {
            this.userRepository = userRepository;
            this.userCommands = userCommands;
        }

        public async Task Delete(Guid id)
        {
            var user = await new UserFinder(userRepository).Find(id);
            await userCommands.DeleteUser(user.Id);
        }
    }
}

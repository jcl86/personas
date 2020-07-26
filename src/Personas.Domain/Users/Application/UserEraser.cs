using System;
using System.Threading.Tasks;

namespace Personas.Domain
{
    public class UserEraser
    {
        private readonly IUserRepository userRepository;

        public UserEraser(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task Delete(Guid id)
        {
            var user = await new UserFinder(userRepository).Find(id);
            await userRepository.DeleteUser(user.Id);
        }
    }
}

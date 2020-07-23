using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Personas.Domain;
using Personas.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Api
{
    [Authorize(Policies.Administrator)]
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository usersRepository;

        public UsersController(IUserRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAll()
        {
            var users = await usersRepository.GetAll();
            return Ok(users.Select(x => Map(x)).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetById(Guid id)
        {
            var entity = await usersRepository.GetUser(id);
            return Ok(Map(entity));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await usersRepository.DeleteUser(id);
            return NoContent();
        }

        private UserViewModel Map(User user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                Username = user.ToString()
            };
        }
    }
}

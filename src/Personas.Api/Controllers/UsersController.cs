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
    [Authorize(Policies.IsAdminPolicy)]
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserFinder userFinder;
        private readonly UserEraser userEraser;

        public UsersController(UserFinder userFinder, UserEraser userEraser)
        {
            this.userFinder = userFinder;
            this.userEraser = userEraser;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAll()
        {
            var users = await userFinder.FindAll();
            return Ok(users.Select(x => Map(x)).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetById(Guid id)
        {
            var entity = await userFinder.Find(id);
            return Ok(Map(entity));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await userEraser.Delete(id);
            return NoContent();
        }

        private UserViewModel Map(User user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                Username = user.ToString(),
                Roles = user.Roles
            };
        }

    }
}

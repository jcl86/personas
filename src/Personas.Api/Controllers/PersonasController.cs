using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Api.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonasController : ControllerBase
    {
        private readonly NombresRepository _context;

        public PersonasController(DataContext context)
        {
            _context = context;
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Post(UserRequest request)
        {
            var isValid = ModelState.IsValid;

            var user = new User
            {
                Name = request.Name,
                Created = DateTime.UtcNow
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpGet, Route("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.Users.FirstOrDefault(u => u.Id == id));
        }
    }
}

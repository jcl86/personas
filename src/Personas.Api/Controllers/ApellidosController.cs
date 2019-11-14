using Microsoft.AspNetCore.Mvc;
using Personas.Core;
using System.Threading.Tasks;

namespace Personas.Api.Controllers
{
    [ApiController]
    [Route("api/apellidos")]
    public class ApellidosController : ControllerBase
    {
        private readonly IApellidosRepository repository;

        public ApellidosController(IApellidosRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet, Route("{numero:int}")]
        public async Task<IActionResult> Get(int numero)
        {
            var personas = await repository.GetApellidos(numero);
            return Ok(personas);
        }
    }
}

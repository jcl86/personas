using Microsoft.AspNetCore.Mvc;
using Personas.Core;
using System.Threading.Tasks;

namespace Personas.Api.Controllers
{
    [ApiController]
    [Route("api/nombres")]
    public class NombresController : ControllerBase
    {
        private readonly INombresRepository repository;

        public NombresController(INombresRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet, Route("{numero:int}")]
        public async Task<IActionResult> Get(int numero)
        {
            var personas = await repository.GetNombres(numero);
            return Ok(personas);
        }

        [HttpGet, Route("hombres/{numero:int}")]
        public async Task<IActionResult> GetHombres(int numero)
        {
            var personas = await repository.GetNombres(numero, Genero.Male);
            return Ok(personas);
        }

        [HttpGet, Route("mujeres/{numero:int}")]
        public async Task<IActionResult> GetMujeres(int numero)
        {
            var personas = await repository.GetNombres(numero, Genero.Female);
            return Ok(personas);
        }
    }
}

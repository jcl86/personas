using Microsoft.AspNetCore.Mvc;
using Personas.Core;
using System.Threading.Tasks;

namespace Personas.Api.Controllers
{
    [ApiController]
    [Route("api/lugares")]
    public class LugaresController : ControllerBase
    {
        private readonly ILugaresRepository repository;

        public LugaresController(ILugaresRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet, Route("{numero:int}")]
        public async Task<IActionResult> Get(int numero = 100)
        {
            var personas = await repository.GetLugares(numero);
            return Ok(personas);
        }

        [HttpGet, Route("{provincia:string}{numero:int}")]
        public async Task<IActionResult> GetFromProvincia(string provincia, int numero = 100)
        {
            var provinciaConvertida = new EnumConverter<Provincia>(provincia).Convert();
            var personas = await repository.GetLugares(numero, provinciaConvertida);
            return Ok(personas);
        }

        [HttpGet, Route("{comunidad:string}{numero:int}")]
        public async Task<IActionResult> GetFromComunidad(string comunidad, int numero = 100)
        {
            var comunidadConvertida = new EnumConverter<Comunidad>(comunidad).Convert();
            var personas = await repository.GetLugares(numero, comunidadConvertida);
            return Ok(personas);
        }
    }
}

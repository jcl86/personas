using Microsoft.AspNetCore.Mvc;
using Personas.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Api
{
    [ApiKeyAuth]
    [ApiController]
    [Route("api/[Controller]")]
    public class NombresController : ControllerBase
    {
        private readonly INombresRepository repository;

        public NombresController(INombresRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet, Route("{numero:int}")]
        public async Task<ActionResult<IEnumerable<NombreViewModel>>> Get(int numero = 100)
        {
            var nombres = await repository.GetNombres(numero);
            return Ok(Map(nombres));
        }

        [HttpGet, Route("hombres/{numero:int}")]
        public async Task<ActionResult<IEnumerable<NombreViewModel>>> GetHombres(int numero = 100)
        {
            var nombres = await repository.GetNombres(numero, Genero.Male);
            return Ok(Map(nombres));
        }

        [HttpGet, Route("mujeres/{numero:int}")]
        public async Task<ActionResult<IEnumerable<NombreViewModel>>> GetMujeres(int numero = 100)
        {
            var nombres = await repository.GetNombres(numero, Genero.Female);
            return Ok(Map(nombres));
        }

        private IEnumerable<NombreViewModel> Map(IEnumerable<Nombre> list) => list.Select(x => new NombreMapper(x).Map()).ToList();
        
    }
}

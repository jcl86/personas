using Microsoft.AspNetCore.Mvc;
using Personas.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Api
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NombreViewModel>>> Get()
        {
            var nombres = await repository.GetNombres(100);
            return Ok(Map(nombres));
        }

        [HttpGet, Route("{numero:int}")]
        public async Task<ActionResult<IEnumerable<NombreViewModel>>> GetNumero(int numero = 100)
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

        private IEnumerable<NombreViewModel> Map(IEnumerable<Nombre> list) => list.Select(x => new NombreViewModel(x)).ToList();
        
    }
}

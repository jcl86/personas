using Microsoft.AspNetCore.Mvc;
using Personas.Core;
using Personas.Data.Repositories;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Api.Controllers
{

    [ApiController]
    [Route("api/personas")]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonasService service;

        public PersonasController(IPersonasService service)
        {
            this.service = service;
        }

        [HttpGet, Route("{numero:int}")]
        public async Task<IActionResult> Get(int numero)
        {
            var personas = await service.GetPersonas(numero);
            return Ok(personas);
        }

        [HttpGet, Route("{comunidad:string}/{numero:int}")]
        public async Task<IActionResult> Get(Comunidad comunidad, int numero)
        {
            var personas = await service.GetPersonas(numero, comunidad);
            return Ok(personas);
        }

        [HttpGet, Route("{provincia:string}/{numero:int}")]
        public async Task<IActionResult> Get(Provincia provincia, int numero)
        {
            var personas = await service.GetPersonas(numero, provincia);
            return Ok(personas);
        }
    }
}

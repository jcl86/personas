using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Personas.Core;
using Personas.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Api
{
    [ApiKeyAuth]
    [ApiController]
    [Route("api/[Controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonasService service;
        private readonly IConfiguration configuration;

        public PersonasController(IPersonasService service, IConfiguration configuration)
        {
            this.service = service;
            this.configuration = configuration;
        }

        [HttpGet, Route("{numero:int}")]
        public async Task<IActionResult> Get(int numero = 100)
        {
            var personas = await service.GetPersonas(numero);
            return Ok(Map(personas));
        }

        [HttpGet, Route("hombres/{numero:int}")]
        public async Task<IActionResult> GetHombres(int numero = 100)
        {
            var personas = await service.GetPersonas(numero, Genero.Male);
            return Ok(Map(personas));
        }

        [HttpGet, Route("mujeres/{numero:int}")]
        public async Task<IActionResult> GetMujeres(int numero = 100)
        {
            var personas = await service.GetPersonas(numero, Genero.Female);
            return Ok(Map(personas));
        }

        [HttpGet, Route("region/{region}/{numero:int}")]
        public async Task<IActionResult> GetFromRegion(string region, int numero = 100)
        {
            var comunidadConvertida = new EnumConverter<Comunidad>(region).Convert();
            var personas = await service.GetPersonas(numero, comunidadConvertida);
            return Ok(Map(personas));
        }

        [HttpGet, Route("hombres/region/{region}/{numero:int}")]
        public async Task<IActionResult> GetHombresFromRegion(string region, int numero = 100)
        {
            var comunidadConvertida = new EnumConverter<Comunidad>(region).Convert();
            var personas = await service.GetPersonas(numero, comunidadConvertida, Genero.Male);
            return Ok(Map(personas));
        }

        [HttpGet, Route("mujeres/region/{region}/{numero:int}")]
        public async Task<IActionResult> GetMujeresFromRegion(string region, int numero = 100)
        {
            var comunidadConvertida = new EnumConverter<Comunidad>(region).Convert();
            var personas = await service.GetPersonas(numero, comunidadConvertida, Genero.Female);
            return Ok(Map(personas));
        }

        [HttpGet, Route("provincia/{provincia}/{numero:int}")]
        public async Task<IActionResult> GetFromProvincia(string provincia, int numero = 100)
        {
            var provinciaConvertida = new EnumConverter<Provincia>(provincia).Convert();
            var personas = await service.GetPersonas(numero, provinciaConvertida);
            return Ok(Map(personas));
        }

        [HttpGet, Route("hombres/provincia/{provincia}/{numero:int}")]
        public async Task<IActionResult> GetHombresFromProvincia(string provincia, int numero = 100)
        {
            var provinciaConvertida = new EnumConverter<Provincia>(provincia).Convert();
            var personas = await service.GetPersonas(numero, provinciaConvertida, Genero.Male);
            return Ok(Map(personas));
        }

        [HttpGet, Route("mujeres/provincia/{provincia}/{numero:int}")]
        public async Task<IActionResult> GetMujeresFromProvincia(string provincia, int numero = 100)
        {
            var provinciaConvertida = new EnumConverter<Provincia>(provincia).Convert();
            var personas = await service.GetPersonas(numero, provinciaConvertida, Genero.Female);
            return Ok(Map(personas));
        }

        private IEnumerable<PersonaViewModel> Map(IEnumerable<Persona> list) => list.Select(x => new PersonaMapper(x).Map()).ToList();
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Personas.Domain;
using Personas.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personas.Shared;

namespace Personas.Api
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly PeopleSearcher searcher;

        public PersonasController(PeopleSearcher searcher)
        {
            this.searcher = searcher;
        }

        [HttpGet, Route("{numero:int}")]
        public async Task<IActionResult> Get(int numero = 100)
        {
            var personas = await searcher.GetPersonas(numero);
            return Ok(Map(personas));
        }

        [HttpGet, Route("hombres/{numero:int}")]
        public async Task<IActionResult> GetHombres(int numero = 100)
        {
            var personas = await searcher.GetPersonas(numero, Gender.Male);
            return Ok(Map(personas));
        }

        [HttpGet, Route("mujeres/{numero:int}")]
        public async Task<IActionResult> GetMujeres(int numero = 100)
        {
            var personas = await searcher.GetPersonas(numero, Gender.Female);
            return Ok(Map(personas));
        }

        [HttpGet, Route("region/{region}/{numero:int}")]
        public async Task<IActionResult> GetFromRegion(string region, int numero = 100)
        {
            var comunidadConvertida = new EnumConverter<AutonomousCommunity>(region).Convert();
            var personas = await searcher.GetPersonas(numero, comunidadConvertida);
            return Ok(Map(personas));
        }

        [HttpGet, Route("hombres/region/{region}/{numero:int}")]
        public async Task<IActionResult> GetHombresFromRegion(string region, int numero = 100)
        {
            var comunidadConvertida = new EnumConverter<AutonomousCommunity>(region).Convert();
            var personas = await searcher.GetPersonas(numero, comunidadConvertida, Gender.Male);
            return Ok(Map(personas));
        }

        [HttpGet, Route("mujeres/region/{region}/{numero:int}")]
        public async Task<IActionResult> GetMujeresFromRegion(string region, int numero = 100)
        {
            var comunidadConvertida = new EnumConverter<AutonomousCommunity>(region).Convert();
            var personas = await searcher.GetPersonas(numero, comunidadConvertida, Gender.Female);
            return Ok(Map(personas));
        }

        [HttpGet, Route("provincia/{provincia}/{numero:int}")]
        public async Task<IActionResult> GetFromProvincia(string provincia, int numero = 100)
        {
            var provinciaConvertida = new EnumConverter<Province>(provincia).Convert();
            var personas = await searcher.GetPersonas(numero, provinciaConvertida);
            return Ok(Map(personas));
        }

        [HttpGet, Route("hombres/provincia/{provincia}/{numero:int}")]
        public async Task<IActionResult> GetHombresFromProvincia(string provincia, int numero = 100)
        {
            var provinciaConvertida = new EnumConverter<Province>(provincia).Convert();
            var personas = await searcher.GetPersonas(numero, provinciaConvertida, Gender.Male);
            return Ok(Map(personas));
        }

        [HttpGet, Route("mujeres/provincia/{provincia}/{numero:int}")]
        public async Task<IActionResult> GetMujeresFromProvincia(string provincia, int numero = 100)
        {
            var provinciaConvertida = new EnumConverter<Province>(provincia).Convert();
            var personas = await searcher.GetPersonas(numero, provinciaConvertida, Gender.Female);
            return Ok(Map(personas));
        }

        private IEnumerable<PersonaViewModel> Map(IEnumerable<Persona> list) => list.Select(x => new PersonaMapper(x).Map()).ToList();
    }
}

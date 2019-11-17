using Microsoft.AspNetCore.Mvc;
using Personas.Core;
using Personas.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Api
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

        [HttpGet, Route("{comunidad}/{numero:int}")]
        public async Task<IActionResult> GetFromComunidad(string comunidad, int numero = 100)
        {
            var comunidadConvertida = new EnumConverter<Provincia>(comunidad).Convert();
            var personas = await service.GetPersonas(numero, comunidadConvertida);
            return Ok(Map(personas));
        }

        [HttpGet, Route("hombres/{comunidad}/{numero:int}")]
        public async Task<IActionResult> GetHombresFromComunidad(string comunidad, int numero = 100)
        {
            var comunidadConvertida = new EnumConverter<Provincia>(comunidad).Convert();
            var personas = await service.GetPersonas(numero, comunidadConvertida, Genero.Male);
            return Ok(Map(personas));
        }

        [HttpGet, Route("mujeres/{comunidad}/{numero:int}")]
        public async Task<IActionResult> GetMujeresFromComunidad(string comunidad, int numero = 100)
        {
            var comunidadConvertida = new EnumConverter<Provincia>(comunidad).Convert();
            var personas = await service.GetPersonas(numero, comunidadConvertida, Genero.Female);
            return Ok(Map(personas));
        }

        [HttpGet, Route("{provincia}/{numero:int}")]
        public async Task<IActionResult> GetFromProvincia(string provincia, int numero = 100)
        {
            var provinciaConvertida = new EnumConverter<Provincia>(provincia).Convert();
            var personas = await service.GetPersonas(numero, provinciaConvertida);
            return Ok(Map(personas));
        }

        [HttpGet, Route("hombres/{provincia}/{numero:int}")]
        public async Task<IActionResult> GetHombresFromProvincia(string provincia, int numero = 100)
        {
            var provinciaConvertida = new EnumConverter<Provincia>(provincia).Convert();
            var personas = await service.GetPersonas(numero, provinciaConvertida, Genero.Male);
            return Ok(Map(personas));
        }

        [HttpGet, Route("mujeres/{provincia}/{numero:int}")]
        public async Task<IActionResult> GetMujeresFromProvincia(string provincia, int numero = 100)
        {
            var provinciaConvertida = new EnumConverter<Provincia>(provincia).Convert();
            var personas = await service.GetPersonas(numero, provinciaConvertida, Genero.Female);
            return Ok(Map(personas));
        }

        private IEnumerable<PersonaViewModel> Map(IEnumerable<Persona> list) => list.Select(x => new PersonaViewModel(x)).ToList();
    }
}

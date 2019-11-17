using Microsoft.AspNetCore.Mvc;
using Personas.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Api
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
            var lugares = await repository.GetLugares(numero);
            return Ok(Map(lugares));
        }

        [HttpGet, Route("{provincia}/{numero:int}")]
        public async Task<IActionResult> GetFromProvincia(string provincia, int numero = 100)
        {
            var provinciaConvertida = new EnumConverter<Provincia>(provincia).Convert();
            var lugares = await repository.GetLugares(numero, provinciaConvertida);
            return Ok(Map(lugares));
        }

        [HttpGet, Route("{comunidad}/{numero:int}")]
        public async Task<IActionResult> GetFromComunidad(string comunidad, int numero = 100)
        {
            var comunidadConvertida = new EnumConverter<Comunidad>(comunidad).Convert();
            var lugares = await repository.GetLugares(numero, comunidadConvertida);
            return Ok(Map(lugares));
        }

        private IEnumerable<LugarViewModel> Map(IEnumerable<Lugar> list) => list.Select(x => new LugarViewModel(x)).ToList();
    }
}

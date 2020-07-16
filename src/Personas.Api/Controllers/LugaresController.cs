using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personas.Domain;
using Personas.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Api
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class LugaresController : ControllerBase
    {
        private readonly IPlacesRepository repository;

        public LugaresController(IPlacesRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet, Route("{numero:int}")]
        public async Task<IActionResult> Get(int numero = 100)
        {
            var lugares = await repository.GetPlaces(numero);
            return Ok(Map(lugares));
        }

        [HttpGet, Route("provincia/{provincia}/{numero:int}")]
        public async Task<IActionResult> GetFromProvincia(string provincia, int numero = 100)
        {
            var provinciaConvertida = new EnumConverter<Province>(provincia).Convert();
            var lugares = await repository.GetLugares(numero, provinciaConvertida);
            return Ok(Map(lugares));
        }

        [HttpGet, Route("region/{region}/{numero:int}")]
        public async Task<IActionResult> GetFromRegion(string region, int numero = 100)
        {
            var comunidadConvertida = new EnumConverter<AutonomousCommunity>(region).Convert();
            var lugares = await repository.GetLugares(numero, comunidadConvertida);
            return Ok(Map(lugares));
        }

        private IEnumerable<PlaceViewModel> Map(IEnumerable<Place> list) => list.Select(x => new LugarMapper(x).Map()).ToList();
    }
}

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
    public class PlacesController : ControllerBase
    {
        private readonly PlaceSearcher placeSearcher;

        public PlacesController(PlaceSearcher placeSearcher)
        {
            this.placeSearcher = placeSearcher;
        }

        [HttpGet, Route("{numero:int}")]
        public async Task<IActionResult> Get(int quantity = 100)
        {
            var lugares = await placeSearcher.Search(quantity);
            return Ok(Map(lugares));
        }

        [HttpGet, Route("province({provincia})/{quantity:int}")]
        public async Task<IActionResult> GetFromProvincia(string province, int quantity = 100)
        {
            var convertedProvince = new EnumConverter<Province>(province).Convert();
            var places = await placeSearcher.Search(quantity, convertedProvince, null);
            return Ok(Map(places));
        }

        [HttpGet, Route("region({region})/{quantity:int}")]
        public async Task<IActionResult> GetFromRegion(string region, int quantity = 100)
        {
            var convertedRegion = new EnumConverter<AutonomousCommunity>(region).Convert();
            var places = await placeSearcher.Search(quantity, null, convertedRegion);
            return Ok(Map(places));
        }

        private IEnumerable<PlaceViewModel> Map(IEnumerable<Place> list) => list.Select(x => new PlaceMapper(x).Map()).ToList();
    }
}

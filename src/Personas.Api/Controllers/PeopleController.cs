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
    [Route("api/people")]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleSearcher searcher;

        public PeopleController(PeopleSearcher searcher)
        {
            this.searcher = searcher;
        }

        [HttpGet, Route("{quantity:int}")]
        public async Task<IActionResult> Get(int quantity = 100)
        {
            var personas = await searcher.SearchPeople(quantity);
            return Ok(Map(personas));
        }

        [HttpGet, Route("men/{quantity:int}")]
        public async Task<IActionResult> GetMen(int quantity = 100)
        {
            var personas = await searcher.SearchPeople(quantity, null, null, Gender.Male);
            return Ok(Map(personas));
        }

        [HttpGet, Route("women/{quantity:int}")]
        public async Task<IActionResult> GetWomen(int quantity = 100)
        {
            var personas = await searcher.SearchPeople(quantity, null, null, Gender.Female);
            return Ok(Map(personas));
        }

        [HttpGet, Route("region({region})/{quantity:int}")]
        public async Task<IActionResult> GetFromRegion(string region, int quantity = 100)
        {
            var convertedRegion = new EnumConverter<AutonomousCommunity>(region).Convert();
            var personas = await searcher.SearchPeople(quantity, null, convertedRegion);
            return Ok(Map(personas));
        }

        [HttpGet, Route("region({region})/men/{quantity:int}")]
        public async Task<IActionResult> GetMenFromRegion(string region, int quantity = 100)
        {
            var convertedRegion = new EnumConverter<AutonomousCommunity>(region).Convert();
            var personas = await searcher.SearchPeople(quantity, null, convertedRegion, Gender.Male);
            return Ok(Map(personas));
        }

        [HttpGet, Route("region({region})/women/{quantity:int}")]
        public async Task<IActionResult> GetWomenFromRegion(string region, int quantity = 100)
        {
            var convertedRegion = new EnumConverter<AutonomousCommunity>(region).Convert();
            var personas = await searcher.SearchPeople(quantity, null, convertedRegion, Gender.Female);
            return Ok(Map(personas));
        }

        [HttpGet, Route("province({province})/{quantity:int}")]
        public async Task<IActionResult> GetFromProvince(string province, int quantity = 100)
        {
            var convertedProvince = new EnumConverter<Province>(province).Convert();
            var personas = await searcher.SearchPeople(quantity, convertedProvince);
            return Ok(Map(personas));
        }

        [HttpGet, Route("province({province})/men/{quantity:int}")]
        public async Task<IActionResult> GetMenFromProvince(string province, int quantity = 100)
        {
            var convertedProvince = new EnumConverter<Province>(province).Convert();
            var personas = await searcher.SearchPeople(quantity, convertedProvince, null, Gender.Male);
            return Ok(Map(personas));
        }

        [HttpGet, Route("province({province})/women/{quantity:int}")]
        public async Task<IActionResult> GetWomenFromProvince(string province, int quantity = 100)
        {
            var convertedProvince = new EnumConverter<Province>(province).Convert();
            var personas = await searcher.SearchPeople(quantity, convertedProvince, null, Gender.Female);
            return Ok(Map(personas));
        }

        private IEnumerable<PersonViewModel> Map(IEnumerable<Person> list) => list.Select(x => new PersonMapper(x).Map()).ToList();
    }
}

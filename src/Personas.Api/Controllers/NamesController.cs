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
    [Route("api/names")]
    public class NamesController : ControllerBase
    {
        private readonly NameSearcher nameSearcher;

        public NamesController(NameSearcher nameSearcher)
        {
            this.nameSearcher = nameSearcher;
        }

        [HttpGet, Route("{count:int}")]
        public async Task<ActionResult<IEnumerable<NameViewModel>>> Get(int count = 100)
        {
            var names = await nameSearcher.Search(count, gender: null);
            return Ok(Map(names));
        }

        [HttpGet, Route("men/{count:int}")]
        public async Task<ActionResult<IEnumerable<NameViewModel>>> GetMen(int count = 100)
        {
            var names = await nameSearcher.Search(count, Gender.Male);
            return Ok(Map(names));
        }

        [HttpGet, Route("women/{count:int}")]
        public async Task<ActionResult<IEnumerable<NameViewModel>>> GetWomen(int count = 100)
        {
            var names = await nameSearcher.Search(count, Gender.Female);
            return Ok(Map(names));
        }

        private IEnumerable<NameViewModel> Map(IEnumerable<Name> list) => list.Select(x => new NameMapper(x).Map()).ToList();
        
    }
}

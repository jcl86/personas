using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personas.Application;
using Personas.Domain;
using Personas.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Api
{
    [Authorize]
    [ApiController]
    [Route("api/surnames")]
    public class SurnamesController : ControllerBase
    {
        private readonly SurnameSearcher surnameSearcher;

        public SurnamesController(SurnameSearcher surnameSearcher)
        {
            this.surnameSearcher = surnameSearcher;
        }

        /// <summary>
        /// Obtiene una lista de apellidos
        /// </summary>
        /// <param name="count">Número de apellidos (mínimo 100)</param>
        /// <returns></returns>
        [HttpGet, Route("{count:int}")]
        public async Task<ActionResult<IEnumerable<SurnameViewModel>>> Get(int count = 100)
        {
            var surnameList = await surnameSearcher.Search(count);
            var result = surnameList.Select(x => new SurnameMapper(x).Map()).ToList();
            return Ok(result);
        }
    }
}

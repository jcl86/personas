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
    public class ApellidosController : ControllerBase
    {
        private readonly IApellidosRepository repository;

        public ApellidosController(IApellidosRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Obtiene una lista de apellidos
        /// </summary>
        /// <param name="numero">Número de apellidos (mínimo 100)</param>
        /// <returns></returns>
        [HttpGet, Route("{numero:int}")]
        public async Task<ActionResult<IEnumerable<ApellidoViewModel>>> Get(int numero = 100)
        {
            var apellidos = await repository.GetApellidos(numero);
            return Ok(Map(apellidos));
        }

        private IEnumerable<ApellidoViewModel> Map(IEnumerable<Apellido> list) => list.Select(x => new ApellidoMapper(x).Map()).ToList();
    }
}

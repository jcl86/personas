﻿using Microsoft.AspNetCore.Mvc;
using Personas.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas.Api
{
    [ApiController]
    [Route("api/apellidos")]
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
        public async Task<IActionResult> Get(int numero = 100)
        {
            var apellidos = await repository.GetApellidos(numero);
            return Ok(Map(apellidos));
        }

        private IEnumerable<ApellidoViewModel> Map(IEnumerable<Apellido> list) => list.Select(x => new ApellidoViewModel(x)).ToList();
    }
}
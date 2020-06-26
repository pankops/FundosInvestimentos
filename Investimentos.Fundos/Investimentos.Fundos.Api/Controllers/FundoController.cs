using Investimentos.Fundos.App.Interface;
using Investimentos.Fundos.App.Model.Response;
using Investimentos.Fundos.App.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investimentos.Fundos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FundoController : ControllerBase
    {
        private readonly IFundoService fundoService;

        public FundoController(IFundoService fundoService)
        {
            this.fundoService = fundoService;
        }

        /// <summary>
        /// Método para consultar todos fundos de investimentos.
        /// </summary>
        /// <returns>Retorna fundos de investimentos.</returns>
        [HttpGet("obter-todos")]
        public async Task<ActionResult<IEnumerable<FundoResponse>>> ObterTodos()
        {
            return Ok(await fundoService.ObterTodos());
        }
    }
}
using Investimentos.Fundos.App.Interface;
using Investimentos.Fundos.App.Model.Request;
using Investimentos.Fundos.App.Model.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investimentos.Fundos.Api.Controllers
{
    /// <summary>
    /// Classe de controle para operações de Fundos de Investimentos.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MovimentoController : ControllerBase
    {
        private readonly IMovimentoService movimentoService;
        private readonly IFundoService fundoService;

        public MovimentoController(IMovimentoService movimentoService,
                                   IFundoService fundoService)
        {
            this.movimentoService = movimentoService;
            this.fundoService = fundoService;
        }

        /// <summary>
        /// Método para consultar operações de aplicação e resgate.
        /// </summary>
        /// <returns>Retorna as operações realizadas.</returns>
        [HttpGet("obter-todos")]
        public async Task<ActionResult<IEnumerable<MovimentoResponse>>> ObterTodos()
        {
            return Ok(await movimentoService.ObterTodos());
        }

        /// <summary>
        /// Método para aplicar um fundo de investimentos.
        /// </summary>
        /// <param name="request">Informações da operação do fundo de investimento.</param>
        /// <returns>Retorna o objeto do movimento.</returns>
        [HttpPost("aplicar")]
        public async Task<ActionResult<MovimentoResponse>> Aplicar([FromBody] MovimentoRequest request)
        {
            var fundo = await fundoService.ObterPorId(request.IdFundo);

            // validar se fundo existe
            if (fundo == null)
            {
                ModelState.AddModelError("IdFundo", "Fundo não encontrado!");

                return NotFound(ModelState);
            }

            var movimento = await movimentoService.ObterPorIdFundoCpf(request.IdFundo, request.CpfCliente);

            if (movimento == null)
            {
                var valido = await movimentoService.ValidarValorMinimoInicial(request, fundo);

                if (!valido)
                {
                    ModelState.AddModelError("ValorMovimento", $"Valor mínimo da aplicação deve ser R$ {fundo.InvestimentoInicialMinimo}!");

                    return BadRequest(ModelState);
                }
            }

            return Ok(await movimentoService.Aplicar(request));
        }

        /// <summary>
        /// Método para resgastar um fundo de investimentos.
        /// </summary>
        /// <param name="request">Informações da operação do fundo de investimento.</param>
        /// <returns>Retorna o objeto do movimento.</returns>
        [HttpPost("resgatar")]
        public async Task<ActionResult<MovimentoResponse>> Resgatar([FromBody] MovimentoRequest request)
        {
            var fundo = await fundoService.ObterPorId(request.IdFundo);

            // validar se fundo existe
            if (fundo == null)
            {
                ModelState.AddModelError("IdFundo", "Fundo não encontrado!");

                return NotFound(ModelState);
            }

            return Ok(await movimentoService.Resgatar(request));
        }
    }
}
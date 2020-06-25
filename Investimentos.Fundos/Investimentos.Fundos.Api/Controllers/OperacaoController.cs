using Investimentos.Fundos.App.Interface;
using Investimentos.Fundos.App.Model.Request;
using Investimentos.Fundos.App.Model.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Investimentos.Fundos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperacaoController : ControllerBase
    {
        private readonly IOperacaoService operacaoService;

        public OperacaoController(IOperacaoService operacaoService)
        {
            this.operacaoService = operacaoService;
        }

        /// <summary>
        /// Método para aplicar em fundo de investimentos.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("aplicar")]
        public async Task<MovimentoResponse> Aplicar([FromBody] MovimentoRequest request)
        {
            //validar se fundo existe
            //validar valor minimo aplicao se 1º aplicação
            return await operacaoService.Aplicar(request);
        }

        [HttpPost("resgatar")]
        public async Task<MovimentoResponse> Resgatar([FromBody] MovimentoRequest request)
        {
            //validar se fundo existe

            return await operacaoService.Aplicar(request);
        }
    }
}
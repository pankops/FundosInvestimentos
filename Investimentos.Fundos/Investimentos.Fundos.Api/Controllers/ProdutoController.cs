using Investimentos.Fundos.App.Model.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investimentos.Fundos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet("obterTodos")]
        public async Task<IEnumerable<FundoResponse>> ObterTodos()
        {
            return new List<FundoResponse>()
            {
                new FundoResponse()
                {
                    CnpjFundo="123",
                    IdFundo= new Guid(),
                    InvestimentoInicialMinimo=12.33M,
                    NomeFundo="Nome"
                }
            };
            // return ("Fundo de investimento não encontrado");
        }
    }
}
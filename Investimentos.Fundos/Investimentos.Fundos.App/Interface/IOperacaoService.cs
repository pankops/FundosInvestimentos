using Investimentos.Fundos.App.Model.Request;
using Investimentos.Fundos.App.Model.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investimentos.Fundos.App.Interface
{
    public interface IOperacaoService
    {
        Task<IEnumerable<MovimentoResponse>> ObterTodos();
        Task<MovimentoResponse> Aplicar(MovimentoRequest movimento);
        Task<MovimentoResponse> Resgatar(MovimentoRequest movimento);
    }
}
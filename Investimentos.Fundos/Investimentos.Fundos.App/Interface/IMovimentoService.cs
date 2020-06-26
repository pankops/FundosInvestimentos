using Investimentos.Fundos.App.Model.Request;
using Investimentos.Fundos.App.Model.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investimentos.Fundos.App.Interface
{
    public interface IMovimentoService
    {
        Task<MovimentoResponse> Aplicar(MovimentoRequest movimento);
        Task<MovimentoResponse> Resgatar(MovimentoRequest movimento);
        Task<IEnumerable<MovimentoResponse>> ObterTodos();
        Task<MovimentoResponse> ObterPorIdFundoCpf(Guid idFundo, string cpf);
        Task<bool> ValidarValorMinimoInicial(MovimentoRequest request, FundoResponse fundo);
    }
}
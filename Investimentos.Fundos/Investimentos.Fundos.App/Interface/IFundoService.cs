using Investimentos.Fundos.App.Model.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investimentos.Fundos.App.Interface
{
    public interface IFundoService
    {
        Task<IEnumerable<FundoResponse>> ObterTodos();
        Task<FundoResponse> ObterPorId(Guid idFundo);
    }
}
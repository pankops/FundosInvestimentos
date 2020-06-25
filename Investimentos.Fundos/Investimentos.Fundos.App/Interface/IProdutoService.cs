using Investimentos.Fundos.App.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investimentos.Fundos.App.Interface
{
    public interface IProdutoService
    {
        Task<IEnumerable<FundoResponse>> ObterTodos();
    }
}
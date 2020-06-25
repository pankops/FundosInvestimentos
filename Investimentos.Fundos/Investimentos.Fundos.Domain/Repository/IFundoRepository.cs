using Investimentos.Fundos.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investimentos.Fundos.Domain.Repository
{
    public interface IFundoRepository
    {
        Task<IEnumerable<Fundo>> ObterTodos();
        Task<Fundo> ObterFundoPorId(Guid idFundo);
    }
}
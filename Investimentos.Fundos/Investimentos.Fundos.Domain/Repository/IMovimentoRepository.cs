using Investimentos.Fundos.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investimentos.Fundos.Domain.Repository
{
    public interface IMovimentoRepository
    {
        Task Adicionar(Movimento movimento);
        Task<IEnumerable<Movimento>> ObterTodos();
        Task<Movimento> ObterPorIdFundoCpf(Guid idFundo, string cpf);
    }
}
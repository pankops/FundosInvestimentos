using Investimentos.Fundos.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investimentos.Fundos.Domain.Repository
{
    public interface IMovimentoRepository
    {
        Task Adicionar(Movimento fundo);
        Task<IEnumerable<Movimento>> ObterTodos();
    }
}
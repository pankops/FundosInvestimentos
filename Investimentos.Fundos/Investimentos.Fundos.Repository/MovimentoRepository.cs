using Investimentos.Fundos.Domain.Model;
using Investimentos.Fundos.Domain.Repository;
using Investimentos.Fundos.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Investimentos.Fundos.Repository
{
    public class MovimentoRepository : BaseRepository, IMovimentoRepository
    {
        public MovimentoRepository(FundosContext context) : base(context)
        { }

        public async Task<IEnumerable<Movimento>> ObterTodos()
        {
            return await context.Movimento.ToListAsync();
        }

        public async Task Adicionar(Movimento fundo)
        {
            await context.Movimento.AddAsync(fundo);
        }
    }
}

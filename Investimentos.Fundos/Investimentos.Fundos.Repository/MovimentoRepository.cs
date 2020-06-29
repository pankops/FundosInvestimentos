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

        public async Task Adicionar(Movimento movimento)
        {
            await context.Movimento.AddAsync(movimento);
        }

        public async Task<IEnumerable<Movimento>> ObterTodos()
        {
            return await context.Movimento
                            .Include(m => m.Fundo)
                            .ToListAsync();
        }

        public Task<Movimento> ObterPorIdFundoCpf(Guid idFundo, string cpf)
        {
            return context.Movimento
                    .FirstOrDefaultAsync(m => m.IdFundo == idFundo
                                        && m.CpfCliente.Equals(cpf));
        }
    }
}
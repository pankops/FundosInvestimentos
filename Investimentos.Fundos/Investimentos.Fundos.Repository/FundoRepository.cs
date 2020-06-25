using Investimentos.Fundos.Domain.Model;
using Investimentos.Fundos.Domain.Repository;
using Investimentos.Fundos.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investimentos.Fundos.Repository
{
    public class FundoRepository : BaseRepository, IFundoRepository
    {
        public FundoRepository(FundosContext context) : base(context)
        { }

        public Task<Fundo> ObterFundoPorId(Guid idFundo)
        {
            return context.Fundo.FirstOrDefaultAsync(m => m.IdFundo == idFundo);
        }

        public async Task<IEnumerable<Fundo>> ObterTodos()
        {
            return await context.Fundo.ToListAsync();
        }
    }
}

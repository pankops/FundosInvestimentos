using Investimentos.Fundos.Domain.Repository;
using Investimentos.Fundos.Repository.Context;
using System.Threading.Tasks;

namespace Investimentos.Fundos.Repository
{
    public class UnitOfWork : BaseRepository, IUnitOfWork
    {
        public UnitOfWork(FundosContext context) : base(context)
        { }

        public async Task Salvar()
        {
            await context.SaveChangesAsync();
        }
    }
}
using Investimentos.Fundos.Repository.Context;

namespace Investimentos.Fundos.Repository
{
    public class BaseRepository
    {
        protected readonly FundosContext context;

        public BaseRepository(FundosContext context)
        {
            this.context = context;
        }
    }
}

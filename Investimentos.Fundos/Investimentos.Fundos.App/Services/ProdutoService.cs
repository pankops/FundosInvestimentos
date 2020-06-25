using AutoMapper;
using Investimentos.Fundos.App.Interface;
using Investimentos.Fundos.App.Model.Response;
using Investimentos.Fundos.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investimentos.Fundos.App.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IFundoRepository fundoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProdutoService(IFundoRepository fundoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.fundoRepository = fundoRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<FundoResponse>> ObterTodos()
        {
            var entity = await fundoRepository.ObterTodos();
            List<FundoResponse> fundos = new List<FundoResponse>();

            foreach (var item in entity)
            {
                var model = mapper.Map<FundoResponse>(item);
                
                fundos.Add(model);
            }

            return fundos;
        }
    }
}
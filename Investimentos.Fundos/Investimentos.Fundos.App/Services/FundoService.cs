using AutoMapper;
using Investimentos.Fundos.App.Interface;
using Investimentos.Fundos.App.Model.Response;
using Investimentos.Fundos.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investimentos.Fundos.App.Services
{
    public class FundoService : IFundoService
    {
        private readonly IFundoRepository fundoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FundoService(IFundoRepository fundoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.fundoRepository = fundoRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<FundoResponse> ObterPorId(Guid idFundo)
        {
            var entity = await fundoRepository.ObterPorId(idFundo);

            return mapper.Map<FundoResponse>(entity);
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
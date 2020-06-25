using AutoMapper;
using Investimentos.Fundos.App.Interface;
using Investimentos.Fundos.App.Model.Request;
using Investimentos.Fundos.App.Model.Response;
using Investimentos.Fundos.Domain.Model;
using Investimentos.Fundos.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investimentos.Fundos.App.Services
{
    public class OperacaoService : IOperacaoService
    {
        private readonly IMovimentoRepository movimentoRepository;
        private readonly IFundoRepository fundoRepository;

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OperacaoService(IMovimentoRepository movimentoRepository,
            IFundoRepository fundoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.movimentoRepository = movimentoRepository;
            this.fundoRepository = fundoRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MovimentoResponse>> ObterTodos()
        {
            var entity = await movimentoRepository.ObterTodos();
            List<MovimentoResponse> movimentos = new List<MovimentoResponse>();

            foreach (var item in entity)
            {
                var model = mapper.Map<MovimentoResponse>(item);
                movimentos.Add(model);
            }

            return movimentos;
        }

        public async Task<MovimentoResponse> Aplicar(MovimentoRequest movimento)
        {
            var fundo = fundoRepository.ObterFundoPorId(movimento.IdFundo);

            if (fundo == null)
            {
                throw new Exception("Fundo não encontrado");
            }

            var entity = mapper.Map<Movimento>(movimento);
            entity.TipoMovimento = TipoMovimento.APLICACAO;

            await movimentoRepository.Adicionar(entity);
            await unitOfWork.Salvar();

            var model = mapper.Map<MovimentoResponse>(movimento);

            return model;
        }

        public async Task<MovimentoResponse> Resgatar(MovimentoRequest movimento)
        {
            var fundo = fundoRepository.ObterFundoPorId(movimento.IdFundo);

            if (fundo == null)
            {
                throw new Exception("Fundo não encontrado");
            }

            var entity = mapper.Map<Movimento>(movimento);
            entity.TipoMovimento = TipoMovimento.RESGATE;

            await movimentoRepository.Adicionar(entity);
            await unitOfWork.Salvar();

            var model = mapper.Map<MovimentoResponse>(movimento);

            return model;
        }
    }
}
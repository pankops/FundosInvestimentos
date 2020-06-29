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
    public class MovimentoService : IMovimentoService
    {
        private readonly IMovimentoRepository movimentoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MovimentoService(IMovimentoRepository movimentoRepository,
                               IUnitOfWork unitOfWork,
                               IMapper mapper)
        {
            this.movimentoRepository = movimentoRepository;
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
                model.NomeFundo = item.Fundo.NomeFundo;
                movimentos.Add(model);
            }

            return movimentos;
        }

        public async Task<MovimentoResponse> Aplicar(MovimentoRequest movimento)
        {
            var entity = mapper.Map<Movimento>(movimento);
            entity.TipoMovimento = TipoMovimento.APLICACAO;

            await movimentoRepository.Adicionar(entity);
            await unitOfWork.Salvar();

            var model = mapper.Map<MovimentoResponse>(entity);

            return model;
        }

        public async Task<MovimentoResponse> Resgatar(MovimentoRequest movimento)
        {
            var entity = mapper.Map<Movimento>(movimento);
            entity.TipoMovimento = TipoMovimento.RESGATE;

            await movimentoRepository.Adicionar(entity);
            await unitOfWork.Salvar();

            var model = mapper.Map<MovimentoResponse>(entity);

            return model;
        }

        public async Task<MovimentoResponse> ObterPorIdFundoCpf(Guid idFundo, string cpf)
        {
            var entity = await movimentoRepository.ObterPorIdFundoCpf(idFundo, cpf);

            return mapper.Map<MovimentoResponse>(entity);
        }

        public async Task<bool> ValidarValorMinimoInicial(MovimentoRequest request, FundoResponse fundo)
        {
            return await Task.FromResult(request.ValorMovimento >= fundo.InvestimentoInicialMinimo);
        }
    }
}
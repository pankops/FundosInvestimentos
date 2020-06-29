using AutoMapper;
using Investimentos.Fundos.App.AutoMapper;
using Investimentos.Fundos.App.Interface;
using Investimentos.Fundos.App.Model.Request;
using Investimentos.Fundos.App.Model.Response;
using Investimentos.Fundos.App.Services;
using Investimentos.Fundos.Domain.Repository;
using Investimentos.Fundos.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Investimentos.Fundos.Test
{    
    public class MovimentoServiceTest : SqliteTest
    {
        readonly IMovimentoService movimentoService;
        readonly IMovimentoRepository movimentoRepository;
        readonly IUnitOfWork unitOfWork;
        readonly IMapper mapper;

        public MovimentoServiceTest()
        {
            mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
            unitOfWork = new UnitOfWork(Context);
            movimentoRepository = new MovimentoRepository(Context);
            movimentoService = new MovimentoService(movimentoRepository, unitOfWork, mapper);
        }

        [Fact]
        public async void RetornaVerdadeiroValorMinimoInicial()
        {
            //Arrange
            var request = new MovimentoRequest()
            {
                ValorMovimento = 6000,
            };

            FundoResponse fundo = new FundoResponse()
            {
                InvestimentoInicialMinimo = 1000
            };

            //Act
            var resultado = await movimentoService.ValidarValorMinimoInicial(request, fundo);

            //Assert
            Assert.True(resultado);
        }

        [Fact]
        public async void RetornaFalsoValorMinimoInicial()
        {
            //Arrange
            var request = new MovimentoRequest()
            {
                ValorMovimento = 1000,
            };

            FundoResponse fundo = new FundoResponse()
            {
                InvestimentoInicialMinimo = 5000
            };

            //Act
            var resultado = await movimentoService.ValidarValorMinimoInicial(request, fundo);

            //Assert
            Assert.False(resultado);
        }
    }
}
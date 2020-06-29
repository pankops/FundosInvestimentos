using AutoMapper;
using Investimentos.Fundos.Api.Controllers;
using Investimentos.Fundos.App.AutoMapper;
using Investimentos.Fundos.App.Interface;
using Investimentos.Fundos.App.Model.Request;
using Investimentos.Fundos.App.Services;
using Investimentos.Fundos.Domain.Repository;
using Investimentos.Fundos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Investimentos.Fundos.Test
{
    public class MovimentoControllerTest : SqliteTest
    {
        readonly MovimentoController movimentoController;
        readonly IMovimentoService movimentoService;
        readonly IMovimentoRepository movimentoRepository;
        readonly IFundoService fundoService;
        readonly IFundoRepository fundoRepository;
        readonly IUnitOfWork unitOfWork;
        readonly IMapper mapper;

        public MovimentoControllerTest()
        {
            mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
            unitOfWork = new UnitOfWork(Context);
            fundoRepository = new FundoRepository(Context);
            fundoService = new FundoService(fundoRepository, unitOfWork, mapper);
            movimentoRepository = new MovimentoRepository(Context);
            movimentoService = new MovimentoService(movimentoRepository, unitOfWork, mapper);
            movimentoController = new MovimentoController(movimentoService, fundoService);

            CarregarFundos();
        }

        private void CarregarFundos()
        {
            List<Domain.Model.Fundo> lista = new List<Domain.Model.Fundo>()
            {
                new Domain.Model.Fundo()
                {
                    IdFundo = new Guid("8A576098-FD61-41D0-8FAA-AA6B6C0ED072"),
                    CnpjFundo = "11628883000103",
                    InvestimentoInicialMinimo = 5000,
                    NomeFundo = "OCCAM FIC FIA"
                },
                new Domain.Model.Fundo()
                {
                    IdFundo = new Guid("825D324A-A903-4C59-AAAC-AB403F75CCCA"),
                    CnpjFundo = "34546979000110",
                    InvestimentoInicialMinimo = 500,
                    NomeFundo = "ICATU VANGUARDA DIVIDENDOS 30 FIA"
                },
                new Domain.Model.Fundo()
                {
                    IdFundo = new Guid("413D6804-088C-430D-8652-71D3E5A34C61"),
                    CnpjFundo = "18860059000115",
                    InvestimentoInicialMinimo = 5000,
                    NomeFundo = "ABSOLUTE HEDGE FIC FIM"
                },
                new Domain.Model.Fundo()
                {
                    IdFundo = new Guid("D81AB40A-496C-4A8F-957A-2AA32323D4D3"),
                    CnpjFundo = "04455632000109",
                    InvestimentoInicialMinimo = 10000,
                    NomeFundo = "AZ QUEST MULTI FIC FIM"
                }
            };

            Context.Fundo.AddRange(lista);
            Context.SaveChanges();
        }

        [Fact]
        public async void RetornaOKBuscarTodos()
        {
            //Arrange

            //Act
            var resultado = await movimentoController.ObterTodos();
            var okResultado = resultado.Result as OkObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(okResultado);
        }

        [Fact]
        public async void RetornaNotFoundAplicarFundoInexistente()
        {
            //Arrange
            var request = new MovimentoRequest()
            {
                IdFundo = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA")
            };

            //Act
            var resultado = await movimentoController.Aplicar(request);
            var notFoundResult = resultado.Result as NotFoundObjectResult;

            //Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public async void RetornaBadRequestAplicarFundoValorAbaixoMinimo()
        {
            //Arrange
            var request = new MovimentoRequest()
            {
                IdFundo = new Guid("8A576098-FD61-41D0-8FAA-AA6B6C0ED072"),
                ValorMovimento = 4000
            };

            //Act
            var resultado = await movimentoController.Aplicar(request);
            var notFoundResult = resultado.Result as BadRequestObjectResult;

            //Assert
            Assert.IsType<BadRequestObjectResult>(notFoundResult);
        }

        [Fact]
        public async void RetornaOkResultAplicarFundoValorAcimaMinimo()
        {
            //Arrange
            var request = new MovimentoRequest()
            {
                IdFundo = new Guid("8A576098-FD61-41D0-8FAA-AA6B6C0ED072"),
                ValorMovimento = 6000,
                CpfCliente = "87229420091",
                DataMovimento = DateTime.Now
            };

            //Act
            var resultado = await movimentoController.Aplicar(request);
            var okObjectResult = resultado.Result as OkObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(okObjectResult);
        }

        [Fact]
        public async void RetornaOkResultAplicarSegundaVezFundoValorAbaixoMinimo()
        {
            //Arrange
            var request = new MovimentoRequest()
            {
                IdFundo = new Guid("825D324A-A903-4C59-AAAC-AB403F75CCCA"),
                ValorMovimento = 500,
                CpfCliente = "87229420091",
                DataMovimento = DateTime.Now
            };

            var requestSegundaAplicacao = new MovimentoRequest()
            {
                IdFundo = new Guid("825D324A-A903-4C59-AAAC-AB403F75CCCA"),
                ValorMovimento = 140,
                CpfCliente = "87229420091",
                DataMovimento = DateTime.Now
            };

            //Act
            _ = await movimentoController.Aplicar(request);
            var resultado = await movimentoController.Aplicar(requestSegundaAplicacao);

            var okObjectResult = resultado.Result as OkObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(okObjectResult);
        }

        [Fact]
        public async void RetornaNotFoundResgatarFundoInexistente()
        {
            //Arrange
            var request = new MovimentoRequest()
            {
                IdFundo = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA")
            };

            //Act
            var resultado = await movimentoController.Resgatar(request);
            var notFoundResult = resultado.Result as NotFoundObjectResult;

            //Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public async void RetornaOkResultResgatarFundoExistente()
        {

            //Arrange
            var request = new MovimentoRequest()
            {
                IdFundo = new Guid("413D6804-088C-430D-8652-71D3E5A34C61"),
                ValorMovimento = 20000,
                CpfCliente = "87229420091",
                DataMovimento = DateTime.Now
            }; 

            //Act
            var resultado = await movimentoController.Resgatar(request);
            var notFoundResult = resultado.Result as OkObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(notFoundResult);            
        }
    }
}

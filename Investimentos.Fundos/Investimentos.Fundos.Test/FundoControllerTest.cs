using AutoMapper;
using Investimentos.Fundos.Api.Controllers;
using Investimentos.Fundos.App.AutoMapper;
using Investimentos.Fundos.App.Interface;
using Investimentos.Fundos.App.Model.Response;
using Investimentos.Fundos.App.Services;
using Investimentos.Fundos.Domain.Repository;
using Investimentos.Fundos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Investimentos.Fundos.Test
{
    public class FundoControllerTest : SqliteTest
    {
        FundoController fundoController;
        readonly IFundoService fundoService;
        readonly IFundoRepository fundoRepository;
        readonly IUnitOfWork unitOfWork;
        readonly IMapper mapper;

        public FundoControllerTest()
        {
            fundoRepository = new FundoRepository(Context);
            unitOfWork = new UnitOfWork(Context);
            mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
            fundoService = new FundoService(fundoRepository, unitOfWork, mapper);
            fundoController = new FundoController(fundoService);

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
            var resultado = await fundoController.ObterTodos();
            var okObjectResult = resultado.Result as OkObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(okObjectResult);
        }

        [Fact]
        public async void RetornaNomeIgualBuscarTodos()
        {
            //Arrange
            string cnpj = "11628883000103";
            string nome = "OCCAM FIC FIA";

            //Act
            var resultado = await fundoController.ObterTodos();
            var fundo = (IEnumerable<FundoResponse>)((OkObjectResult)resultado.Result).Value;

            string nomeAtual = fundo.First(m => m.CnpjFundo.Equals(cnpj)).NomeFundo;

            //Assert
            Assert.Equal(nome, nomeAtual);
        }
    }
}

using AutoMapper;
using Investimentos.Fundos.App.Model.Response;
using Investimentos.Fundos.Domain.Model;

namespace Investimentos.Fundos.App.AutoMapper
{
    public class DomainToModelMapping : Profile
    {
        public DomainToModelMapping()
        {
            CreateMap<Movimento, MovimentoResponse>();
            CreateMap<Fundo, FundoResponse>();
        }
    }
}
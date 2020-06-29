using AutoMapper;
using Investimentos.Fundos.App.Model.Request;
using Investimentos.Fundos.Domain.Model;

namespace Investimentos.Fundos.App.AutoMapper
{
    public class ModelToDomainMapping : Profile
    {
        public ModelToDomainMapping()
        {
            CreateMap<MovimentoRequest, Movimento>();
        }
    }
}
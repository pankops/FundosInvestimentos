using AutoMapper;

namespace Investimentos.Fundos.App.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToModelMapping());
                cfg.AddProfile(new ModelToDomainMapping());
            });
        }
    }
}
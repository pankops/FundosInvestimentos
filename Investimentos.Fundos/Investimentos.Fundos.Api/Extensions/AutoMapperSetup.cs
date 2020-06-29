using AutoMapper;
using Investimentos.Fundos.App.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Investimentos.Fundos.Api.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            AutoMapperConfig.RegisterMappings();
        }
    }
}

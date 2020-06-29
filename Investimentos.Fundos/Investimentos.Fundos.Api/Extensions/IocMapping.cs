using Investimentos.Fundos.App.Interface;
using Investimentos.Fundos.App.Services;
using Investimentos.Fundos.Domain.Repository;
using Investimentos.Fundos.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investimentos.Fundos.Api.Extensions
{
    public static class IocMappingInfra
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMovimentoService, MovimentoService>();
            services.AddScoped<IFundoService, FundoService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMovimentoRepository, MovimentoRepository>();
            services.AddScoped<IFundoRepository, FundoRepository>();
        }
    }
}

using Investimentos.Fundos.Domain.Parameters;
using Investimentos.Fundos.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investimentos.Fundos.Api.Extensions
{
    public static class DataBaseSetup
    {
        public static void AddDataBaseSetup(this IServiceCollection services)
        {
            services.AddDbContextPool<FundosContext>(options =>
                options.UseSqlServer(ApiParameters.DbStringConexao));
        }
    }
}

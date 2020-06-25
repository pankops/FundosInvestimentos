using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Investimentos.Fundos.Api.Extensions
{
    public static class JsonSetup
    {
        public static void AddJsonSetup(this IServiceCollection services)
        {
            services.Configure<JsonOptions>(options =>
            {
                var optionsJsonSerializerOptions = options.JsonSerializerOptions;
                optionsJsonSerializerOptions.IgnoreNullValues = true;
                optionsJsonSerializerOptions.PropertyNameCaseInsensitive = true;
                optionsJsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                optionsJsonSerializerOptions.MaxDepth = 256;
                //optionsJsonSerializerOptions.ReferenceHandling = ReferenceHandling.Preserve;
            });
        }
    }
}

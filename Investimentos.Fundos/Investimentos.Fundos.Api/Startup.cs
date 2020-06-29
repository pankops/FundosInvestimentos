using FluentValidation.AspNetCore;
using Investimentos.Fundos.Api.Extensions;
using Investimentos.Fundos.Domain.Parameters;
using Investimentos.Fundos.Repository.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Investimentos.Fundos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ApiParameters.CarregarParametros();
            services.AddControllers();
            services.AddJsonSetup();
            services.RegisterServices();
            services.AddAutoMapperSetup();
            services.AddSwaggerSetup();
            services.AddDataBaseSetup();

            services.AddMvc().AddFluentValidation((mvcConfiguration => mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Startup>()));

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwaggerSetup();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
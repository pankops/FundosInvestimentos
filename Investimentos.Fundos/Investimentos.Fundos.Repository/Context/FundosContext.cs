using Investimentos.Fundos.Domain.Model;
using Investimentos.Fundos.Repository.EnitityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Investimentos.Fundos.Repository.Context
{
    public class FundosContext : DbContext
    {
        public DbSet<Fundo> Fundo { get; set; }
        public DbSet<Movimento> Movimento { get; set; }

        public FundosContext(DbContextOptions<FundosContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FundoConfig());
            modelBuilder.ApplyConfiguration(new MovimentoConfig());
        }
    }
}
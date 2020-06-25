using Investimentos.Fundos.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Investimentos.Fundos.Repository.EnitityConfig
{
    public class FundoConfig : IEntityTypeConfiguration<Fundo>
    {
        public void Configure(EntityTypeBuilder<Fundo> builder)
        {
            builder.Property(m => m.IdFundo)
            .IsRequired();

            builder.HasKey(s => s.IdFundo);

            builder.Property(m => m.NomeFundo)         
            .IsRequired();

            builder.Property(m => m.CnpjFundo)
            .IsRequired();

            builder.Property(m => m.InvestimentoInicialMinimo)
            .IsRequired();
        }
    }
}
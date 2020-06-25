using Investimentos.Fundos.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Investimentos.Fundos.Repository.EnitityConfig
{
    public class MovimentoConfig : IEntityTypeConfiguration<Movimento>
    {
        public void Configure(EntityTypeBuilder<Movimento> builder)
        {
            builder.Property(m => m.IdMovimento)
            .IsRequired();

            builder.HasKey(s => s.IdMovimento);

            builder.Property(m => m.TipoMovimento)
            .IsRequired();

            builder.Property(m => m.IdFundo)
            .IsRequired();

            builder.Property(m => m.CpfCliente)
            .IsRequired();

            builder.Property(m => m.ValorMovimento)
            .IsRequired();

            builder.Property(m => m.DataMovimento)
            .IsRequired();

            builder.HasOne(m => m.Fundo)
            .WithMany(m => m.Movimentos)
            .HasForeignKey(m => m.IdFundo);
        }
    }
}
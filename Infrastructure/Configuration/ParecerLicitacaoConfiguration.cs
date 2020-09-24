using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ParecerLicitacaoConfiguration : IEntityTypeConfiguration<ParecerLicitacao>
    {
        public void Configure(EntityTypeBuilder<ParecerLicitacao> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.Edital).WithMany().OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Resultado).IsRequired().HasMaxLength(20);

            builder.HasOne(p => p.MotivoPerda).WithMany().OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Vencedor).WithMany().OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Responsavel).WithMany().OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Anexo1).WithMany().OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Anexo2).WithMany().OnDelete(DeleteBehavior.SetNull);
        }
    }
}

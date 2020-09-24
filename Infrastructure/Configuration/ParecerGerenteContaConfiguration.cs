using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ParecerGerenteContaConfiguration : IEntityTypeConfiguration<ParecerGerenteConta>
    {
        public void Configure(EntityTypeBuilder<ParecerGerenteConta> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.Edital).WithMany().OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Parecer).IsRequired();

            builder.Property(p => p.Natureza).IsRequired();

            builder.HasOne(p => p.MotivoComum).WithMany().OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Empresa).WithMany().OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.PreVenda).WithMany().OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Anexo1).WithMany().OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Anexo2).WithMany().OnDelete(DeleteBehavior.SetNull);
        }
    }
}

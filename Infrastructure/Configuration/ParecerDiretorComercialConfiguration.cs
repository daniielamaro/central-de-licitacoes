using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ParecerDiretorComercialConfiguration : IEntityTypeConfiguration<ParecerDiretorComercial>
    {
        public void Configure(EntityTypeBuilder<ParecerDiretorComercial> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.Edital).WithMany().OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Decisao)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasOne(p => p.Empresa).WithMany().OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.MotivosComum).WithMany().OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Gerente).WithMany().OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Anexo1).WithMany().OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Anexo2).WithMany().OnDelete(DeleteBehavior.SetNull);
        }
    }
}

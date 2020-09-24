using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class AnexoConfiguration : IEntityTypeConfiguration<Anexo>
    {
        public void Configure(EntityTypeBuilder<Anexo> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder
                .Property(e => e.Nome)
                .IsRequired();

            builder
                .Property(e => e.Tipo)
                .IsRequired();

            builder
                .Property(e => e.Base64)
                .IsRequired()
                .HasColumnType("MediumBlob");
        }
    }
}

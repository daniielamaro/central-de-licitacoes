using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder
                .Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .HasOne(e => e.Bu).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}

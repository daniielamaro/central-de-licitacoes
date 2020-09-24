using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class CarteiraContaConfiguration : IEntityTypeConfiguration<CarteiraConta>
    {
        public void Configure(EntityTypeBuilder<CarteiraConta> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.Gerente).WithMany().OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(p => p.Cliente).WithMany().OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class BuConfiguration : IEntityTypeConfiguration<Bu>
    {
        public void Configure(EntityTypeBuilder<Bu> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder
                .Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

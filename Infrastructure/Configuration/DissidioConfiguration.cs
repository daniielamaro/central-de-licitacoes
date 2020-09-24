using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class DissidioConfiguration : IEntityTypeConfiguration<Dissidio>
    {
        public void Configure(EntityTypeBuilder<Dissidio> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.Estado).WithMany().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Arquivo).WithMany().OnDelete(DeleteBehavior.SetNull);
        }
    }
}

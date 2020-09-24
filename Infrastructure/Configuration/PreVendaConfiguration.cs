using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class PreVendaConfiguration : IEntityTypeConfiguration<PreVenda>
    {
        public void Configure(EntityTypeBuilder<PreVenda> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.Usuario).WithMany().OnDelete(DeleteBehavior.Cascade);
        }
    }
}

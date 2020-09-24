using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ModalidadeConfiguration : IEntityTypeConfiguration<Modalidade>
    {
        public void Configure(EntityTypeBuilder<Modalidade> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder
                .Property(m => m.Nome)
                .IsRequired();
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ConcorrenteConfiguration : IEntityTypeConfiguration<Concorrente>
    {
        public void Configure(EntityTypeBuilder<Concorrente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder
                .Property(c => c.Nome)
                .IsRequired();

            builder
                .Property(c => c.Apelido);

            builder
                .Property(c => c.Cnpj)
                .IsRequired()
                .HasMaxLength(20);

        }
    }
}

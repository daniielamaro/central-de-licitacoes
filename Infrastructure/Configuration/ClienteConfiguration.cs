using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder
                .Property(u => u.Nome)
                .IsRequired();

            builder
                .Property(u => u.Apelido)
                .IsRequired();

            builder
                .Property(u => u.Cnpj)
                .HasMaxLength(20);
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class HistoricoConfiguration : IEntityTypeConfiguration<Historico>
    {
        public void Configure(EntityTypeBuilder<Historico> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder
                .Property(u => u.Descricao)
                .IsRequired();

            builder.HasOne(x => x.Responsavel).WithMany().OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Edital).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}

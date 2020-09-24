using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class EditalConfiguration : IEntityTypeConfiguration<Edital>
    {
        public void Configure(EntityTypeBuilder<Edital> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder
                .Property(u => u.NumEdital)
                .IsRequired();

            builder
                .HasOne(u => u.Cliente)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.Estado)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.Modalidade)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(u => u.Etapa)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(u => u.DataHoraDeAbertura)
                .IsRequired();

            builder
                .Property(u => u.Uasg)
                .IsRequired();

            builder
                .HasOne(u => u.Categoria)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(u => u.Consorcio)
                .IsRequired();

            builder
                .Property(u => u.AgendarVistoria)
                .IsRequired();

            builder
                .HasOne(u => u.Regiao)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.Gerente)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.Diretor)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.Portal)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .HasMany(u => u.Comentarios)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(u => u.Anexo)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

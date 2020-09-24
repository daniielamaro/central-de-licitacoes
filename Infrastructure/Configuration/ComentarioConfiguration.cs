using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder
                .Property(c => c.Mensagem)
                .IsRequired();

            builder
                .HasOne(c => c.Usuario)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

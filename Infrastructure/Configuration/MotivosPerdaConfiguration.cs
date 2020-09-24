using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class MotivosPerdaConfiguration : IEntityTypeConfiguration<MotivosPerda>
    {
        public void Configure(EntityTypeBuilder<MotivosPerda> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder
                .Property(u => u.Nome)
                .IsRequired();
        }
    }
}

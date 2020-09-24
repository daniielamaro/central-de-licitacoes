﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class MotivosComumConfiguration : IEntityTypeConfiguration<MotivosComum>
    {
        public void Configure(EntityTypeBuilder<MotivosComum> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder
                .Property(u => u.Nome)
                .IsRequired();
        }
    }
}

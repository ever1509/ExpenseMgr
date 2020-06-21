using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistance.Configurations
{
    class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.CategoryId);
            builder.Property(e => e.CategoryId).ValueGeneratedOnAdd();
            builder.Property(e => e.Description).IsRequired().HasColumnType("varchar(20)");
            builder.Property(e => e.ImageName).IsRequired().HasColumnType("varchar(200)");
            builder.Property(e => e.Image).IsRequired(false);
        }
    }
}

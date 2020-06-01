using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    public class TypeExpenseConfiguration : IEntityTypeConfiguration<TypeExpense>
    {
        public void Configure(EntityTypeBuilder<TypeExpense> builder)
        {
            builder.HasKey(e => e.TypeExpenseId);
            builder.Property(e => e.Description).IsRequired().HasColumnType("varchar(20)");
        }
    }
}

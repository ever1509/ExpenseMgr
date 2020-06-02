using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Persistance.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(e => e.TransactionId);
            builder.Property(e => e.TransactionId).ValueGeneratedOnAdd();
            builder.Property(e => e.Value).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(e => e.Name).IsRequired().HasColumnType("varchar(50)");
            builder.Property(e => e.Description).IsRequired(false);
            builder.Property(e => e.TransactionDate).IsRequired().HasColumnType("date");
            builder.Property(e => e.TypeTransaction).IsRequired().HasColumnType("int");


            builder.HasOne(e => e.Category)
                .WithMany(d => d.Transactions)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaction_Category");

            builder.HasOne(e => e.TypeExpense)
                .WithMany(d => d.Transactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(e=>e.TypeExpenseId)
                .HasConstraintName("FK_Transaction_TypeExpense");
        }
    }
}

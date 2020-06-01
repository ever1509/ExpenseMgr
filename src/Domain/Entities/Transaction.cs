using System;
using Domain.Enums;

namespace Domain.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime TransactionDate { get; set; }
        public TypeTransaction TypeTransaction { get; set; }
        public int CategoryId { get; set; }
        public int TypeExpenseId { get; set; }

        public virtual  Category Category { get; set; }
        public virtual TypeExpense TypeExpense { get; set; }

    }
}

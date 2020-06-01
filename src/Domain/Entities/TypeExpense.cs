using System.Collections.Generic;

namespace Domain.Entities
{
    public class TypeExpense
    {
        public TypeExpense()
        {
            Transactions= new HashSet<Transaction>();
        }
        public int TypeExpenseId { get; set; }
        public string Description { get; set; }

        public ICollection<Transaction> Transactions { get;}
    }
}

using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Transactions= new HashSet<Transaction>();
        }

        public int CategoryId { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public ICollection<Transaction> Transactions { get;}
    }
}

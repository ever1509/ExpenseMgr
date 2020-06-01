using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;
using MediatR;

namespace Application.Transactions.Commands.AddTransactionCommand
{
    public class AddTransactionCommand:IRequest<bool>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int CategoryId { get; set; }
        public int TypeExpenseId { get; set; }
        public TypeTransaction TypeTransaction { get; set; }
        public string Description { get; set; }
    }
}

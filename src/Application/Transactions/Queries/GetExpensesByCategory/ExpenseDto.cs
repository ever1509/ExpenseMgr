using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Mappings;
using AutoMapper;

namespace Application.Transactions.Queries.GetExpensesByCategory
{
    public class ExpenseDto
    {
        public string Category { get; set; }
        public decimal Total { get; set; }
    }
}

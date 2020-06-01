using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Transactions.Queries.GetTotalExpenses
{
    public class GetTotalExpensesQueryHandler:IRequestHandler<GetTotalExpensesQuery,decimal>
    {
        private readonly IExpenseContext _context;
        public GetTotalExpensesQueryHandler(IExpenseContext context)
        {
            _context = context;
        }
        public async Task<decimal> Handle(GetTotalExpensesQuery request, CancellationToken cancellationToken)
        {
            var total = await _context.Transactions
                .Where(t => t.TypeExpenseId == (int) TypeExpense.Expense)
                .SumAsync(t => t.Value,cancellationToken);

            return total;

        }
    }
}

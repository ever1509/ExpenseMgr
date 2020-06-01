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

namespace Application.Transactions.Queries.GetTotalIncomes
{
    public class GetTotalIncomesQueryHandler:IRequestHandler<GetTotalIncomesQuery,decimal>
    {
        private readonly IExpenseContext _context;

        public GetTotalIncomesQueryHandler(IExpenseContext context)
        {
            _context = context;
        }
        public async Task<decimal> Handle(GetTotalIncomesQuery request, CancellationToken cancellationToken)
        {
            var total = await _context.Transactions
                .Where(t => t.TypeExpenseId == (int) TypeExpense.Income)
                .SumAsync(t => t.Value, cancellationToken);

            return total;
        }
    }
}

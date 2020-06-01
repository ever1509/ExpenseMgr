using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Transactions.Queries.GetExpensesByCategory
{
    public class GetExpensesByCategoryQueryHandler:IRequestHandler<GetExpensesByCategoryQuery,ExpenseListViewModel>
    {
        private readonly IExpenseContext _context;
        private readonly IMapper _mapper;

        public GetExpensesByCategoryQueryHandler(IExpenseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ExpenseListViewModel> Handle(GetExpensesByCategoryQuery request, CancellationToken cancellationToken)
        {
            var expenses = await _context.Transactions
                .Include(e => e.Category)
                .Where(e=>e.TypeExpenseId== (int)TypeExpense.Expense)
                .GroupBy(e => e.Category.Description)
                .Select(t=>new ExpenseDto()
                {
                    Category = t.Key,
                    Total = t.Sum(x=>x.Value)
                }).ToListAsync(cancellationToken);

            return new ExpenseListViewModel()
            {
                Expenses = expenses
            };

        }
    }
}

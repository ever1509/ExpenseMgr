using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TypeExpense = Domain.Enums.TypeExpense;

namespace Application.Transactions.Commands.AddTransactionCommand
{
    public class AddTransactionCommandHandler:IRequestHandler<AddTransactionCommand,bool>
    {
        private readonly IExpenseContext _context;

        public AddTransactionCommandHandler(IExpenseContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            if (request.TypeExpenseId == (int) TypeExpense.Expense)
            {
                var entity = new Transaction()
                {
                    Name = request.Name,
                    Value = request.Value,
                    TypeExpenseId = request.TypeExpenseId,
                    CategoryId = request.CategoryId,
                    TransactionDate = DateTime.UtcNow,
                    TypeTransaction = request.TypeTransaction,
                    Description = request.Description
                };

                _context.Transactions.Add(entity);

                await UpdatingIncomes(cancellationToken, request.Value,(TypeExpense)request.TypeExpenseId);
            }
            else
            {
                await UpdatingIncomes(cancellationToken, request.Value, (TypeExpense)request.TypeExpenseId);
            }
            

            return true;
        }

        private async Task UpdatingIncomes(CancellationToken cancellationToken, decimal newExpense,
            TypeExpense typeExpense)
        {
            var totalSalary = await _context.Transactions.AsNoTracking()
                .Include(c => c.Category)
                .Where(t => t.Category.CategoryId == 1)
                .GroupBy(t => t.TransactionId)
                .Select(t => new SalaryDto()
                {
                    Id = t.Key,
                    Value = t.Sum(s => s.Value)
                }).FirstOrDefaultAsync(cancellationToken);

            var entity = await _context.Transactions.FirstOrDefaultAsync(t=>t.TransactionId==totalSalary.Id,cancellationToken);

            switch (typeExpense)
            {
                case TypeExpense.Expense:
                    entity.Value = totalSalary.Value - newExpense;
                    break;
                case TypeExpense.Income:
                    entity.Value = totalSalary.Value + newExpense;
                    break;
            }
            
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

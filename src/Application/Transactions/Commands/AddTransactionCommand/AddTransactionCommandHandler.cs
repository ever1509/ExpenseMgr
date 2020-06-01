using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

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

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}

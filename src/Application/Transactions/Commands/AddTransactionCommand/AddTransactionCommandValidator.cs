using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Application.Transactions.Commands.AddTransactionCommand
{
    public class AddTransactionCommandValidator:AbstractValidator<AddTransactionCommand>
    {
        public AddTransactionCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.Value).NotEmpty();
            RuleFor(e => e.CategoryId).NotEmpty();
            RuleFor(e => e.TypeExpenseId).NotEmpty();
            RuleFor(e => e.TypeTransaction).NotEmpty();
            
        }
    }
}

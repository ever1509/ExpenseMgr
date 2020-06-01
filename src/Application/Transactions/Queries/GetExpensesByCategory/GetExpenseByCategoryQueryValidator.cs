using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Application.Transactions.Queries.GetExpensesByCategory
{
    public class GetExpenseByCategoryQueryValidator:AbstractValidator<GetExpensesByCategoryQuery>
    {
        public GetExpenseByCategoryQueryValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
        }
    }
}

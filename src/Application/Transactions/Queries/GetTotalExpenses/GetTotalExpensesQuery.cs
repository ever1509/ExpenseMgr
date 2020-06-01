using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Application.Transactions.Queries.GetTotalExpenses
{
    public class GetTotalExpensesQuery:IRequest<decimal>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Application.Transactions.Queries.GetTotalIncomes
{
    public class GetTotalIncomesQuery:IRequest<decimal>
    {
    }
}

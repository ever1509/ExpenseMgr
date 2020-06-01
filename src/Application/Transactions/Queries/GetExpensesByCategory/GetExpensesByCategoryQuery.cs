using MediatR;

namespace Application.Transactions.Queries.GetExpensesByCategory
{
    public class GetExpensesByCategoryQuery:IRequest<ExpenseListViewModel>
    {
        public int Id { get; set; }
    }
}

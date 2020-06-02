using System.Threading.Tasks;
using Application.Categories.Commands.AddCategoryCommand;
using Application.Categories.Queries.GetCategoriesQuery;
using Application.Transactions.Commands.AddTransactionCommand;
using Application.Transactions.Queries.GetExpensesByCategory;
using Application.Transactions.Queries.GetTotalExpenses;
using Application.Transactions.Queries.GetTotalIncomes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/transactions/")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AddTransactionCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _mediator.Send(new GetCategoriesQuery());

            return Ok(result);
        }

        [HttpPost("addcategory")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("expensesbycategory")]
        public async Task<IActionResult> GetExpenses()
        {
            var result = await _mediator.Send(new GetExpensesByCategoryQuery());

            return Ok(result);
        }

        [HttpGet("expenses")]
        public async Task<IActionResult> GetTotalExpenses()
        {
            var result = await _mediator.Send(new GetTotalExpensesQuery());

            return Ok(result);
        }

        [HttpGet("incomes")]
        public async Task<IActionResult> GetTotalIncomes()
        {
            var result = await _mediator.Send(new GetTotalIncomesQuery());

            return Ok(result);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Categories.Commands.AddCategoryCommand;
using Application.Categories.Queries.GetCategoriesQuery;
using Application.Transactions.Commands.AddTransactionCommand;
using Application.Transactions.Queries.GetExpensesByCategory;
using Application.Transactions.Queries.GetTotalExpenses;
using Application.Transactions.Queries.GetTotalIncomes;
using FakeItEasy;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ExpenseManager.UnitTests.API.Base
{
    public class ControllerTestBase<T> where T:class
    {
        public readonly IMediator _mediatorFake;
        public readonly ILogger<T> _loggerFake;
        public const decimal TOTAL_EXPENSES_FAKE=300;
        
        public const decimal TOTAL_INCOMES_FAKE=200;
        public ControllerTestBase()
        {
            _mediatorFake = A.Fake<IMediator>();
            _loggerFake = A.Fake<ILogger<T>>();

            ConfigureMediatorFake(_mediatorFake);
        }

        private void ConfigureMediatorFake(IMediator mediatorFake)
        {
            A.CallTo(() => mediatorFake.Send(A<AddCategoryCommand>._, A<CancellationToken>._)).Returns(true);
            A.CallTo(() => mediatorFake.Send(A<GetCategoriesQuery>._, A<CancellationToken>._)).Returns(GetCategoriesFake());
            A.CallTo(() => mediatorFake.Send(A<AddTransactionCommand>._, A<CancellationToken>._)).Returns(true);
            
            A.CallTo(() => mediatorFake.Send(A<GetExpensesByCategoryQuery>._, A<CancellationToken>._))
                .Returns(GetExpensesByCategoryFake());
            A.CallTo(() => mediatorFake.Send(A<GetTotalExpensesQuery>._, A<CancellationToken>._))
                .Returns(TOTAL_EXPENSES_FAKE);
            A.CallTo(() => mediatorFake.Send(A<GetTotalIncomesQuery>._, A<CancellationToken>._))
                .Returns(TOTAL_INCOMES_FAKE);

        }

        private Task<ExpenseListViewModel> GetExpensesByCategoryFake()
        {
            throw new NotImplementedException();
        }

        private Task<CategoriesListViewModel> GetCategoriesFake()
        {
            return Task.Run(() => new CategoriesListViewModel()
            {
                Categories = new List<CategoryDto>()
                {
                    new CategoryDto() { Id = 1, Description = "Test1"},
                    new CategoryDto() { Id = 2, Description = "Test2"},
                    new CategoryDto() { Id = 3, Description = "Test3"},
                    new CategoryDto() { Id = 4, Description = "Test4"},
                    new CategoryDto() { Id = 5, Description = "Test5"},
                    new CategoryDto() { Id = 6, Description = "Test6"}



                }
            });
        }
    }
}

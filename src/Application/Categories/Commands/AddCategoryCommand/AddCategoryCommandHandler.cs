using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Categories.Commands.AddCategoryCommand
{
    public class AddCategoryCommandHandler:IRequestHandler<AddCategoryCommand,bool>
    {
        private readonly IExpenseContext _context;

        public AddCategoryCommandHandler(IExpenseContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(Commands.AddCategoryCommand.AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Category()
            {
                Description = request.Description
            };

            _context.Categories.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}

using MediatR;

namespace Application.Categories.Commands.AddCategoryCommand
{
    public class AddCategoryCommand:IRequest<bool>
    {
        public string Description { get; set; }
    }
}

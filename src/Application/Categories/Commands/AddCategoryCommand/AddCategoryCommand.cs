using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Categories.Commands.AddCategoryCommand
{
    public class AddCategoryCommand:IRequest<bool>
    {
        public string Description { get; set; }
        public IFormFile ImageFile { get; set; }        
    }
}

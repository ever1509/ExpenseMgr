using FluentValidation;

namespace Application.Categories.Commands.AddCategoryCommand
{
    public class AddCategoryCommandValidator:AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(e => e.Description).NotEmpty().WithMessage("Its necessary a description for cateogory");
            RuleFor(e => e.Description).MaximumLength(20).WithMessage("Description needs to be short");
        }
    }
}

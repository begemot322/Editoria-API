using FluentValidation;

namespace Editoria.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("id не может быть пустым")
            .GreaterThan(0).WithMessage("id должно быть больше 0");
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Имя не может быть пустым")
            .NotNull().WithMessage("Имя не может быть null")
            .MaximumLength(150);
    }
}
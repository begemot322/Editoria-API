using FluentValidation;

namespace Editoria.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Имя не может быть пустым")
            .NotNull().WithMessage("Имя не может быть null")
            .MaximumLength(150);
    }
}
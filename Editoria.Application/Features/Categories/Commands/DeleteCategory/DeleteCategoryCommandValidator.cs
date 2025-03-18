using FluentValidation;

namespace Editoria.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("id не может быть пустым")
            .GreaterThan(0).WithMessage("id должно быть больше 0");
    }
}
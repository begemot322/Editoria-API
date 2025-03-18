using FluentValidation;

namespace Editoria.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("Id не может быть пустым.");
    }
}
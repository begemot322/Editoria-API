using Editoria.Application.Features.Categories.Queries.GetCategoryById;
using FluentValidation;

namespace Editoria.Application.Features.Articles.Queries.GetArticleById;

public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("Id не может быть пустым.");
    }
}
using FluentValidation;

namespace Editoria.Application.Features.Authors.Queries.GetAuthorById;

public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
{
    public GetAuthorByIdQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("Id не может быть пустым.");
    }
}
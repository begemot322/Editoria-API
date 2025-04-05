using FluentValidation;

namespace Editoria.Application.Features.Authors.Commands.DeleteAuthor;

public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
{
    public DeleteAuthorCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("id не может быть пустым")
            .GreaterThan(0).WithMessage("id должно быть больше 0");
    }
}
 
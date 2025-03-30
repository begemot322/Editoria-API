using Editoria.Domain.Entities;
using FluentValidation;

namespace Editoria.Application.Features.Articles.Commands.DeleteArticle;

public class DeleteArticleCommandValidator : AbstractValidator<Article>
{
    public DeleteArticleCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("id не может быть пустым")
            .GreaterThan(0).WithMessage("id должно быть больше 0");
    }
}
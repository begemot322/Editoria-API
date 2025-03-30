using FluentValidation;

namespace Editoria.Application.Features.Articles.Commands.UpdateArticle;

public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
{
    public UpdateArticleCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Заголовок не может быть пустым")
            .NotNull().WithMessage("Заголовок не может быть null")
            .MaximumLength(150).WithMessage("Заголовок не может быть длиннее 150 символов");
        
        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Некорректный статус");
        
        RuleFor(x => x.AuthorId)
            .GreaterThan(0).WithMessage("ID автора должен быть положительным");
        
        RuleFor(x => x.PublicationDate)
            .Must(BeNotInFuture).WithMessage("Дата публикации не может быть в будущем");
    }
    
    private static bool BeNotInFuture(DateTime dateOfPublish)
    {
        return dateOfPublish <= DateTime.Today;
    }
}
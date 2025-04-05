using FluentValidation;

namespace Editoria.Application.Features.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Имя не может быть пустым")
            .NotNull().WithMessage("Имя не может быть null")
            .MaximumLength(50);
        
        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Имя не может быть пустым")
            .NotNull().WithMessage("Имя не может быть null")
            .MaximumLength(50);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Номер телефона обязателен")
            .NotNull().WithMessage("Номер телефона не может быть null")
            .Matches(@"^[0-9]+$").WithMessage("Неверный формат номера телефон");

        RuleFor(x => x.Biography)
            .MaximumLength(2000).WithMessage("Биография не может превышать 2000 символов");
    }
}
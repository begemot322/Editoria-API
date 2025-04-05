using MediatR;

namespace Editoria.Application.Features.Authors.Commands.UpdateAuthor;

public class UpdateAuthorCommand : IRequest<Unit>
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public string PhoneNumber { get; init; }
    public string Biography { get; init; }
}
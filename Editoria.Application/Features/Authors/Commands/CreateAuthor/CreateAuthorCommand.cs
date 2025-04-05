using MediatR;

namespace Editoria.Application.Features.Authors.Commands.CreateAuthor;

public class CreateAuthorCommand : IRequest<int>
{
    public string Name { get; init; }
    public string Surname { get; init; }
    public string PhoneNumber { get; init; }
    public string Biography { get; init; }
}
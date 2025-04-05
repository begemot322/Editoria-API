using MediatR;

namespace Editoria.Application.Features.Authors.Commands.DeleteAuthor;

public class DeleteAuthorCommand : IRequest<Unit>
{
    public int Id { get; init; }

    public DeleteAuthorCommand(int id)
    {
        Id = id;
    }
}
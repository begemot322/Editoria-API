using MediatR;

namespace Editoria.Application.Features.Articles.Commands.DeleteArticle;

public class DeleteArticleCommand : IRequest<Unit>
{
    public int Id { get; init; }

    public DeleteArticleCommand(int id)
    {
        Id = id;
    }
}
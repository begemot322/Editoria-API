using Editoria.Domain.Entities;
using Editoria.Domain.Enums;
using MediatR;

namespace Editoria.Application.Features.Articles.Commands.UpdateArticle;

public class UpdateArticleCommand : IRequest<Unit>
{
    public int Id { get; init; }
    
    public string Title { get; init; }
    
    public string Text { get; init; }
    
    public DateTime PublicationDate { get; init; }

    public ArticleStatus Status { get; init; }

    public int AuthorId { get; init; }
    
    public List<int> CategoryIds { get; init; } = new List<int>();
}

using Editoria.Domain.Enums;
using MediatR;

namespace Editoria.Application.Features.Articles.Commands.CreateArticle;

public class CreateArticleCommand : IRequest<int>
{
    public string Title { get; init; }
    
    public string Text { get; init; }
    
    public DateTime PublicationDate { get; init; }

    public ArticleStatus Status { get; init; }

    public int AuthorId { get; init; }
    
    public int CategoryId { get; init; }
}
using Editoria.Application.Features.Articles.Queries.Dtos;
using MediatR;

namespace Editoria.Application.Features.Articles.Queries.GetArticleById;

public class GetArticleByIdQuery : IRequest<ArticleDto> 
{
    public int Id { get; init; }
    
    public GetArticleByIdQuery(int id)
    {
        Id = id;
    }
}
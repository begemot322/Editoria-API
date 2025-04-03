using Editoria.Application.Common;
using Editoria.Application.Features.Articles.Queries.Dtos;
using MediatR;

namespace Editoria.Application.Features.Articles.Queries.GetPagedArticles;

public class GetPagedArticlesQuery : IRequest<PaginatedList<ArticlePageDto>>
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }

    public GetPagedArticlesQuery(int pageNumber, int pageSize ) 
    {
        PageNumber = pageNumber > 0 ? pageNumber : 1; 
        PageSize = pageSize > 0 ? pageSize : 10;   
    }
}
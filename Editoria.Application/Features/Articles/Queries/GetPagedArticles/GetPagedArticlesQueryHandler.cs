using Editoria.Application.Common;
using Editoria.Application.Common.Interfaces;
using Editoria.Application.Features.Articles.Queries.Dtos;
using Editoria.Domain.Entities;
using MediatR;

namespace Editoria.Application.Features.Articles.Queries.GetPagedArticles;

public class GetPagedArticlesQueryHandler : IRequestHandler<GetPagedArticlesQuery, PaginatedList<ArticlePageDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPagedArticlesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<PaginatedList<ArticlePageDto>> Handle(GetPagedArticlesQuery request, CancellationToken cancellationToken)
    {
        var articles = await _unitOfWork.Articles.GetPagedAsync(request.PageNumber, request.PageSize);

        return new PaginatedList<ArticlePageDto>(
            articles.Items.Select(article => new ArticlePageDto
            {
                Id = article.Id,
                Title = article.Title,
                Text = article.Text,
                PublicationDate = article.PublicationDate,
                Status = article.Status.ToString(),
            }).ToList(),
            articles.TotalCount,
            request.PageNumber,
            request.PageSize
        );
    }
}
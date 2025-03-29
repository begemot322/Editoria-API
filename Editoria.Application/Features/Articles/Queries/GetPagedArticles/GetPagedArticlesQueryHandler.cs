using Editoria.Application.Common;
using Editoria.Application.Common.Interfaces;
using Editoria.Domain.Entities;
using MediatR;

namespace Editoria.Application.Features.Articles.Queries.GetPagedArticles;

public class GetPagedArticlesQueryHandler : IRequestHandler<GetPagedArticlesQuery, PaginatedList<Article>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPagedArticlesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<PaginatedList<Article>> Handle(GetPagedArticlesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Articles.GetPagedAsync(request.PageNumber, request.PageSize);
    }
}
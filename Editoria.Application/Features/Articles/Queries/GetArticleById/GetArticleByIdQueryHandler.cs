using Editoria.Application.Common.Exceptions;
using Editoria.Application.Common.Interfaces;
using Editoria.Application.Features.Articles.Queries.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Editoria.Application.Features.Articles.Queries.GetArticleById;

public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, ArticleDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRedisCacheService _cache;
    private readonly ILogger<GetArticleByIdQueryHandler> _logger;

    public GetArticleByIdQueryHandler(
        IUnitOfWork unitOfWork, 
        IRedisCacheService cache,
        ILogger<GetArticleByIdQueryHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _cache = cache;
        _logger = logger;
    }

    
    public async Task<ArticleDto> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"article_{request.Id}";

        var cachedArticle = await _cache.GetDataAsync<ArticleDto>(cacheKey, cancellationToken);
        if (cachedArticle != null)
        {
            _logger.LogInformation("Returning cached article {ArticleId}", request.Id);   
            return cachedArticle;
        }
            
        var article = await _unitOfWork.Articles.GetArticleWithDetailsAsync(request.Id);
        
        if (article == null)
            throw new NotFoundException(request.Id);
        
        var articleDto = new ArticleDto
        {
            Id = article.Id,
            Title = article.Title,
            Text = article.Text,
            PublicationDate = article.PublicationDate,
            Status = article.Status.ToString(),
            AuthorId = article.Author.Id,
            CategoryIds = article.ArticleCategories
                .Select(ac => ac.Category.Id)
                .ToList()
        };

        _cache.SetDataAsync($"article_{articleDto.Id}", articleDto, cancellationToken);
        return articleDto;
    }
}
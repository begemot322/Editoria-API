using Editoria.Application.Common.Exceptions;
using Editoria.Application.Common.Interfaces;
using Editoria.Application.Features.Articles.Queries;
using Editoria.Domain.Entities;
using MediatR;

namespace Editoria.Application.Features.Articles.Queries.GetArticleById;

public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, ArticleDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetArticleByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ArticleDto> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
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
            Author = new AuthorShortDto()
            {
                Id = article.Author.Id,
                Name = article.Author.Name,
                Surname = article.Author.Surname,
            },
            Categories = article.ArticleCategories
                .Select(ac => new CategoryShortDto()
                {
                    Id = ac.Category.Id,
                    Name = ac.Category.Name
                }).ToList()
        };
        return articleDto;
    }
}
using Editoria.Application.Common.Exceptions;
using Editoria.Application.Common.Interfaces;
using Editoria.Domain.Entities;
using MediatR;

namespace Editoria.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.Categories.GetCategoryWithArticlesAsync(request.Id);
        
        if (category == null)
            throw new NotFoundException(request.Id);

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            Articles = category.ArticleCategories.Select(a => new ArticleShortDto
            {
                Id = a.Article.Id,
                Title = a.Article.Title,
                PublicationDate = a.Article.PublicationDate
            }).ToList()
        };
    }
}
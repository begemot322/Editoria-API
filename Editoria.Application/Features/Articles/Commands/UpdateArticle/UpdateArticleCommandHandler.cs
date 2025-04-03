using Editoria.Application.Common.Exceptions;
using Editoria.Application.Common.Interfaces;
using Editoria.Domain.Entities;
using MediatR;

namespace Editoria.Application.Features.Articles.Commands.UpdateArticle;

public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRedisCacheService _cache;

    public UpdateArticleCommandHandler(IUnitOfWork unitOfWork, IRedisCacheService cache)
    {
        _unitOfWork = unitOfWork;
        _cache = cache;
    }

    public async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        var article = await _unitOfWork.Articles.GetArticleWithDetailsAsync(request.Id, tracked:true);

        if (article == null)
            throw new NotFoundException(request.Id);

        article.Title = request.Title;
        article.Text = request.Text;
        article.PublicationDate = request.PublicationDate;
        article.Status = request.Status;    
        article.AuthorId = request.AuthorId;
        
        article.ArticleCategories.Clear(); 
        
        var categories = await _unitOfWork.Categories
            .GetAllAsync(c => request.CategoryIds.Contains(c.Id), tracked:true);

        foreach (var category in categories)    
        {
            article.ArticleCategories.Add(new ArticleCategory
            {
                Article = article,
                Category = category
            });
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        await _cache.RemoveDataAsync($"article_{request.Id}", cancellationToken);

        return Unit.Value;
    }
}
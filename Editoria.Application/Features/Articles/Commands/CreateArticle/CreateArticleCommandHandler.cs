using Editoria.Application.Common.Interfaces;
using Editoria.Domain.Entities;
using MediatR;

namespace Editoria.Application.Features.Articles.Commands.CreateArticle;

public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateArticleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {

        var article = new Article()
        {
            Title = request.Title,
            Text = request.Text,
            PublicationDate = request.PublicationDate,
            Status = request.Status,
            AuthorId = request.AuthorId,
        };

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

        await _unitOfWork.Articles.AddAsync(article);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return article.Id;
    }
}

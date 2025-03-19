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
        var category = await _unitOfWork.Categories.GetByIdAsync(request.CategoryId);

        var article = new Article()
        {
            Title = request.Title,
            Text = request.Text,
            PublicationDate = request.PublicationDate,
            Status = request.Status,
            AuthorId = request.AuthorId,
        };

        article.ArticleCategories = new List<ArticleCategory>()
        {
            new ArticleCategory()
            {
                Article = article,
                Category = category
            }
        };

        await _unitOfWork.Articles.AddAsync(article);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return article.Id;
    }
}
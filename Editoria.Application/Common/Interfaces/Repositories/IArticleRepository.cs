using Editoria.Domain.Entities;

namespace Editoria.Application.Common.Interfaces.Repositories;

public interface IArticleRepository : IRepository<Article>
{
    Task<Article?> GetArticleWithDetailsAsync(int articleId);
}
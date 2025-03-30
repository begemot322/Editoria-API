using Editoria.Domain.Entities;

namespace Editoria.Application.Common.Interfaces.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetCategoryWithArticlesAsync(int articleId);
}
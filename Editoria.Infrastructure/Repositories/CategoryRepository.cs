using Editoria.Application.Common.Interfaces.Repositories;
using Editoria.Domain.Entities;
using Editoria.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Editoria.Infrastructure.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly ApplicationDbContext _db;

    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    
    public async Task<Category?> GetCategoryWithArticlesAsync(int categoryId)
    {
        return await _db.Set<Category>()
            .Include(a => a.ArticleCategories)
                .ThenInclude(ac => ac.Article)
            .FirstOrDefaultAsync(a => a.Id == categoryId);
        
    }
}
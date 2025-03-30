using Editoria.Application.Common.Interfaces.Repositories;
using Editoria.Domain.Entities;
using Editoria.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Editoria.Infrastructure.Repositories;

public class ArticleRepository : Repository<Article>, IArticleRepository
{
    private readonly ApplicationDbContext _db;

    public ArticleRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public async Task<Article?> GetArticleWithDetailsAsync(int articleId, bool tracked = false)
    {
        IQueryable<Article> query = _db.Set<Article>();

        if (!tracked)
            query = query.AsNoTracking();

        return await query
            .Include(a => a.Author)
            .Include(a => a.ArticleCategories)
                .ThenInclude(ac => ac.Category)
            .FirstOrDefaultAsync(a => a.Id == articleId);

    }
}   
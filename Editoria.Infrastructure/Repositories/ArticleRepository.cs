using Editoria.Application.Common.Interfaces.Repositories;
using Editoria.Domain.Entities;
using Editoria.Infrastructure.Persistence;

namespace Editoria.Infrastructure.Repositories;

public class ArticleRepository : Repository<Article>, IArticleRepository
{
    public ArticleRepository(ApplicationDbContext db) 
        : base(db) { }
}   
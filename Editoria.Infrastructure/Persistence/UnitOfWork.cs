using Editoria.Application.Common.Interfaces;
using Editoria.Application.Common.Interfaces.Repositories;
using Editoria.Infrastructure.Repositories;

namespace Editoria.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;

    private IArticleRepository _articleRepository;
    private IAuthorRepository _authorRepository;
    private ICategoryRepository _categoryRepository;

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public IArticleRepository Articles => 
        _articleRepository ??= new ArticleRepository(_db);

    public IAuthorRepository Authors => 
        _authorRepository ??= new AuthorRepository(_db);
    
    public ICategoryRepository Categories => 
        _categoryRepository ??= new CategoryRepository(_db);
    
    public void Dispose()
    {
        _db.Dispose();
    }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _db.SaveChangesAsync(cancellationToken);
    }
}
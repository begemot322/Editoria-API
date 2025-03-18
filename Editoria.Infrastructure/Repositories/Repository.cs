using System.Linq.Expressions;
using Editoria.Application.Common.Interfaces.Repositories;
using Editoria.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Editoria.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet; 

    public Repository(ApplicationDbContext db)
    {
        _dbSet = db.Set<T>();
    }
    
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }
    
    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = _dbSet;
        
        if (filter != null)
            query = query.Where(filter);

        return await query.AsNoTracking().ToListAsync();
    }
    
    public async Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = _dbSet;
        
        if (filter != null)
            query = query.Where(filter);
        
        return await query.AsNoTracking().FirstOrDefaultAsync();
    }
    
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    
    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
    
    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
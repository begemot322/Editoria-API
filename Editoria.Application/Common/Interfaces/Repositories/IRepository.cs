using System.Linq.Expressions;

namespace Editoria.Application.Common.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,
        bool tracked = false, string? includeProperties = null);
    Task<PaginatedList<T>> GetPagedAsync(int pageNumber, int pageSize,
        Expression<Func<T, bool>>? filter = null);

    Task<T?> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null,
        bool tracked = false);
    void Delete(T entity);
    void Update(T entity);
}
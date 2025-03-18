using System.Linq.Expressions;

namespace Editoria.Application.Common.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
    Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null);
    Task<T?> GetByIdAsync(int id);
    void Delete(T entity);
    void Update(T entity);
}
using Editoria.Application.Common.Interfaces.Repositories;

namespace Editoria.Application.Common.Interfaces;

public interface IUnitOfWork
{
    IArticleRepository Articles { get; }
    IAuthorRepository Authors { get; }
    ICategoryRepository Categories { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
using Editoria.Application.Common.Interfaces.Repositories;
using Editoria.Domain.Entities;
using Editoria.Infrastructure.Persistence;

namespace Editoria.Infrastructure.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext db) 
        : base(db) { }
}
using Editoria.Application.Common.Interfaces.Repositories;
using Editoria.Domain.Entities;

namespace Editoria.Infrastructure.Persistence.Repositories;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    public AuthorRepository(ApplicationDbContext db) 
        : base(db) { }
}   

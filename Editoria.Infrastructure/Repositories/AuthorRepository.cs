using Editoria.Application.Common.Interfaces.Repositories;
using Editoria.Domain.Entities;
using Editoria.Infrastructure.Persistence;

namespace Editoria.Infrastructure.Repositories;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    public AuthorRepository(ApplicationDbContext db) 
        : base(db) { }
}   

using Editoria.Application.Features.Authors.Queries.Dtos;
using MediatR;

namespace Editoria.Application.Features.Authors.Queries.GetAuthorById;

public class GetAuthorByIdQuery : IRequest<AuthorDto>
{
    public int Id { get; init; }
    
    public GetAuthorByIdQuery(int id)
    {
        Id = id;
    }
}
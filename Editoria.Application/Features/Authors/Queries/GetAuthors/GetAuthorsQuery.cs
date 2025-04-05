using Editoria.Application.Features.Authors.Queries.Dtos;
using MediatR;

namespace Editoria.Application.Features.Authors.Queries.GetAuthors;

public class GetAuthorsQuery : IRequest<IEnumerable<AuthorListDto>>
{
    
}
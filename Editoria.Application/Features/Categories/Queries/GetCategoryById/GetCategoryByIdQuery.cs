using Editoria.Domain.Entities;
using MediatR;

namespace Editoria.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<Category>
{
    public int Id { get; init; }
    
    public GetCategoryByIdQuery(int id)
    {
        Id = id;
    }
}
using Editoria.Application.Features.Categories.Queries.Dtos;
using MediatR;

namespace Editoria.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public int Id { get; init; }
    
    public GetCategoryByIdQuery(int id)
    {
        Id = id;
    }
}
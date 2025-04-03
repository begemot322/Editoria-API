using Editoria.Application.Features.Categories.Queries.Dtos;
using MediatR;

namespace Editoria.Application.Features.Categories.Queries.GetCategories;

public class GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
{
    public GetCategoriesQuery()
    {
        
    }
}
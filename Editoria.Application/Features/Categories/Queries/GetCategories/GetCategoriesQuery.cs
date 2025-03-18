using Editoria.Domain.Entities;
using MediatR;

namespace Editoria.Application.Features.Categories.Queries.GetCategories;

public class GetCategoriesQuery : IRequest<IEnumerable<Category>>
{
    public GetCategoriesQuery()
    {
        
    }
}
using Editoria.Domain.Entities;
using MediatR;

namespace Editoria.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<Unit>
{
    public int Id { get; init; }
    
    public string Name { get; init; }
    
    public string Description { get; init; }
}


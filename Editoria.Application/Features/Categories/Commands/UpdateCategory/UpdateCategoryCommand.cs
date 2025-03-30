using Editoria.Domain.Entities;
using MediatR;

namespace Editoria.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<UpdateCategoryResult>
{
    public int Id { get; init; }
    
    public string Name { get; init; }
    
    public string Description { get; init; }
}

public class UpdateCategoryResult
{
    public Category? Data { get; set; }
}
using Editoria.Domain.Entities;
using MediatR;

namespace Editoria.Application.Features.Categories.Commands.CreateCategory;


public class CreateCategoryCommand : IRequest<int>
{
    public string Name { get; init; }
    public string Description { get; init; }
}
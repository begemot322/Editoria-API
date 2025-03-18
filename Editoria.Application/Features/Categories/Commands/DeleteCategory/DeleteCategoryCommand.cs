using MediatR;

namespace Editoria.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest
{
    public int Id { get; init; }

    public DeleteCategoryCommand(int id)
    {
        Id = id;
    }
}
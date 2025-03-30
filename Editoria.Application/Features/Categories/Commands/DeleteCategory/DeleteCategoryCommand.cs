using MediatR;

namespace Editoria.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<Unit>
{
    public int Id { get; init; }

    public DeleteCategoryCommand(int id)
    {
        Id = id;
    }
}
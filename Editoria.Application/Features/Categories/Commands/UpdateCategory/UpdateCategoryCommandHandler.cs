using Editoria.Application.Common.Exceptions;
using Editoria.Application.Common.Interfaces;
using Editoria.Domain.Entities;
using MediatR;

namespace Editoria.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.Categories.GetAsync(c=>c.Id == request.Id);

        if (category == null)
            throw new NotFoundException(request.Id);

        category.Name = request.Name;
        category.Description = request.Description;

        _unitOfWork.Categories.Update(category);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
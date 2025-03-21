﻿using Editoria.Application.Common.Exceptions;
using Editoria.Application.Common.Interfaces;
using MediatR;

namespace Editoria.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(request.Id);

        if (category == null)
        {
            throw new NotFoundException(request.Id);
        }
        
        _unitOfWork.Categories.Delete(category);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
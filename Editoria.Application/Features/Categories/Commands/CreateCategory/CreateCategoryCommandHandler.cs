using Editoria.Application.Common.Interfaces;
using Editoria.Domain.Entities;
using MediatR;

namespace Editoria.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.Name, 
            Description = request.Description,
        };
        
        await _unitOfWork.Categories.AddAsync(category);    

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}
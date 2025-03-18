using Editoria.Application.Common.Exceptions;
using Editoria.Application.Common.Interfaces;
using Editoria.Domain.Entities;
using MediatR;

namespace Editoria.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(request.Id);

        if (category == null)
            throw new NotFoundException(request.Id);

        return category;
    }
}
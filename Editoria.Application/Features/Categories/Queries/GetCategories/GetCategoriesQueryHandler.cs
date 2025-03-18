using Editoria.Application.Common.Interfaces;
using Editoria.Domain.Entities;
using MediatR;

namespace Editoria.Application.Features.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoriesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _unitOfWork.Categories.GetAllAsync();

        return categories;
    }
}
using Editoria.Application.Common.Interfaces;
using Editoria.Application.Features.Authors.Queries.Dtos;
using MediatR;

namespace Editoria.Application.Features.Authors.Queries.GetAuthors;

public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, IEnumerable<AuthorListDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAuthorsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<AuthorListDto>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _unitOfWork.Authors.GetAllAsync();

        return authors.Select(author => new AuthorListDto
        {
            Id = author.Id,
            Name = author.Name,
            Surname = author.Surname,
            PhoneNumber = author.PhoneNumber,
            Biography = author.Biography
        });
    }
}
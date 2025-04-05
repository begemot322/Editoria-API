using Editoria.Application.Common.Exceptions;
using Editoria.Application.Common.Interfaces;
using Editoria.Application.Features.Authors.Queries.Dtos;
using MediatR;

namespace Editoria.Application.Features.Authors.Queries.GetAuthorById;

public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAuthorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await _unitOfWork.Authors.GetAsync(a => a.Id == request.Id, includeProperties: "Articles");
        
        if (author == null)
            throw new NotFoundException(request.Id);

        return new AuthorDto()
        {
            Name = author.Name,
            Surname = author.Surname,
            PhoneNumber = author.PhoneNumber,
            Biography = author.Biography,
            ArtilesIds = author.Articles
                .Select(a => a.Id)
                .ToList()
        };
    }
}
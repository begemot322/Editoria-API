using Editoria.Application.Common.Interfaces;
using Editoria.Application.Features.Articles.Commands.CreateArticle;
using Editoria.Domain.Entities;
using MediatR;

namespace Editoria.Application.Features.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAuthorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = new Author()
        {
            Name = request.Name,
            Surname = request.Surname,
            PhoneNumber = request.PhoneNumber,
            Biography = request.Biography
        };

        await _unitOfWork.Authors.AddAsync(author);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return author.Id;
    }
}
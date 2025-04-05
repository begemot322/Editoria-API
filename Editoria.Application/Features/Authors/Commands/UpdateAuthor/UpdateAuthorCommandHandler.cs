using Editoria.Application.Common.Exceptions;
using Editoria.Application.Common.Interfaces;
using MediatR;

namespace Editoria.Application.Features.Authors.Commands.UpdateAuthor;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _unitOfWork.Authors.GetAsync(a => a.Id == request.Id);

        if (author == null)
            throw new NotFoundException(request.Id);

        author.Name = request.Name;
        author.Surname = request.Surname;
        author.PhoneNumber = request.PhoneNumber;
        author.Biography = request.Biography;

        _unitOfWork.Authors.Update(author);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
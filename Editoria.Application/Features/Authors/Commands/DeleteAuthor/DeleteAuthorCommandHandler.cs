using Editoria.Application.Common.Exceptions;
using Editoria.Application.Common.Interfaces;
using MediatR;

namespace Editoria.Application.Features.Authors.Commands.DeleteAuthor;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _unitOfWork.Authors.GetAsync(a => a.Id == request.Id);
        
        if (author == null)
        {
            throw new NotFoundException(request.Id);
        }

        _unitOfWork.Authors.Delete(author);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
        
    }
}
using Editoria.Application.Common.Exceptions;
using Editoria.Application.Common.Interfaces;
using MediatR;

namespace Editoria.Application.Features.Articles.Commands.DeleteArticle;

public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteArticleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
        var article = await _unitOfWork.Articles.GetAsync(a => a.Id == request.Id);

        if (article == null)
            throw new NotFoundException(request.Id);
        
        _unitOfWork.Articles.Delete(article);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
using System.Net;
using MediatR.NotificationPublishers;

namespace Editoria.Application.Common.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(int id) : base(HttpStatusCode.NotFound, $"Entity with id {id} was not found")
    {
        
    }
}
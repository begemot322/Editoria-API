using System.Net;
using MediatR.NotificationPublishers;

namespace Editoria.Application.Common.Exceptions;

public class NotFoundException(int id)
    : ApplicationException(HttpStatusCode.NotFound, $"Entity with id {id} was not found");
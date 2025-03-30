using System.Net;

namespace Editoria.Application.Common.Exceptions;

public abstract class ApplicationException(HttpStatusCode statusCode, string message) : Exception(message)
{
    public HttpStatusCode ApplicationErrorCode { get; init; } = statusCode;
}
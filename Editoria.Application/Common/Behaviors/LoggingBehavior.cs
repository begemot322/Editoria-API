using MediatR;
using Microsoft.Extensions.Logging;

namespace Editoria.Application.Common.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling Request {@RequestName} : {@DateTimeUtc}",
            typeof(TRequest).Name, DateTime.UtcNow);
        try
        {
            var response = await next();

            _logger.LogInformation(
                "Handled {RequestName} with response: {@Response}",
                typeof(TRequest).Name,
                response);

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(   
                "Error handling {RequestName}: {@Request} with message " + ex.Message,
                typeof(TRequest).Name,
                request);

            throw;
        }
    }
}
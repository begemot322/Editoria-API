using Editoria.Application.Common.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Editoria.Web.Filters;

public class ApiExceptionFilter : IExceptionFilter
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public ApiExceptionFilter()
    {
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            { typeof(ValidationException), HandleValidationException },
            { typeof(NotFoundException), HandleNotFoundException }
        };
    }
    

    public void OnException(ExceptionContext context)
    {
        HandleException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        Type type = context.Exception.GetType();
        if (_exceptionHandlers.ContainsKey(type))
        {
            _exceptionHandlers[type].Invoke(context);
            return;
        }
        HandleUnknownException(context);
    }

    private void HandleUnknownException(ExceptionContext context)
    {
        context.Result = new ContentResult
        {
            StatusCode = StatusCodes.Status500InternalServerError,
            Content = $"An unexpected error occurred: {context.Exception.Message}"
        };
        context.ExceptionHandled = true;
    }
    
    private void HandleValidationException(ExceptionContext context)
    {
        var exception = context.Exception as ValidationException;

        var errors = exception.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
        
        var validationErrorDetails  = new
        {
            Message = "Validation failed",
            Errors = errors
        };
        
        context.Result = new BadRequestObjectResult(validationErrorDetails);
        
        context.ExceptionHandled = true;
    }
    
    private void HandleNotFoundException(ExceptionContext context)
    {
        var exception = context.Exception as NotFoundException;
        
        context.Result = new NotFoundObjectResult(exception.Message);
        
        context.ExceptionHandled = true;
    }
}




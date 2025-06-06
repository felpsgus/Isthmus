using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Isthmus.Api;

public class ExceptionHandler : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        var problemDetails = exception switch
        {
            ValidationException => new ProblemDetails()
            {
                Status = StatusCodes.Status400BadRequest,
                Type = exception.GetType().Name,
                Title = "Bad request",
                Detail = exception.Message,
                Extensions =
                {
                    ["failures"] = ((ValidationException)exception).Errors
                }
            },
            _ => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = exception.GetType().Name,
                Title = "Server error",
                Detail = exception.Message
            }
        };

        httpContext.Response.StatusCode = (int)problemDetails.Status;
        httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return new ValueTask<bool>(true);
    }
}
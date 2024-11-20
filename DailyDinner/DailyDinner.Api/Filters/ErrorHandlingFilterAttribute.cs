using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DailyDinner.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Title = "An error occurred while processing your request",
            Status = (int)HttpStatusCode.InternalServerError,
            Detail = exception.StackTrace
        };

        var errorResult = new { problemDetails };

        context.Result = new ObjectResult(errorResult);
     
        context.ExceptionHandled = true;
    }
}

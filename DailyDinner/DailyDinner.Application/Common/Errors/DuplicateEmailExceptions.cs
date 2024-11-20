using System.Net;

namespace DailyDinner.Application.Common.Errors;

public class DuplicateEmailExceptions : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Email already exists.";
}
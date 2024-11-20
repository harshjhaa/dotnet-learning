using DailyDinner.Application.Services.Authentication.Common;

namespace DailyDinner.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    AuthenticationResult Login(string email, string password);
}
using DailyDinner.Application.Services.Authentication.Common;
using MediatR;

namespace DailyDinner.Application.Authentication.Commands.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<AuthenticationResult>;
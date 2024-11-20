using DailyDinner.Application.Services.Authentication.Common;
using MediatR;

namespace DailyDinner.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<AuthenticationResult>;
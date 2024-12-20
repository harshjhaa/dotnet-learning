using DailyDinner.Domain.Entities;

namespace DailyDinner.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);
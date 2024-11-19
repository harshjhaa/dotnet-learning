using DailyDinner.Domain.Entities;

namespace DailyDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);
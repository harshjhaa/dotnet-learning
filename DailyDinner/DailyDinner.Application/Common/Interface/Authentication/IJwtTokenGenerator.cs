using DailyDinner.Domain.Entities;

namespace DailyDinner.Application.Common.Interface.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
namespace DailyDinner.Application.Interface.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string firstName, string lastName);
}
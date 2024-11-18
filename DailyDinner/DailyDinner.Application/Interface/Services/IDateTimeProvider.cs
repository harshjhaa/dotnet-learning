namespace DailyDinner.Application.Interface.Authentication;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
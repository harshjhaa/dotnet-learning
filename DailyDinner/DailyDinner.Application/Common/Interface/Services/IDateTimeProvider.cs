namespace DailyDinner.Application.Common.Interface.Authentication;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
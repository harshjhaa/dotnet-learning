using DailyDinner.Application.Common.Interface.Authentication;

namespace DailyDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{    
    public DateTime UtcNow => DateTime.UtcNow;
}
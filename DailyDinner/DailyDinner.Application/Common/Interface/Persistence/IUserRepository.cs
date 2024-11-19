using DailyDinner.Domain.Entities;

namespace DailyDinner.Application.Common.Interface.Persistence;

public interface IUserRepository
{
    void AddUser(User user);
    User? GetUserByEmail(string email);
}

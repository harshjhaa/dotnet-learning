using DailyDinner.Application.Common.Interface.Persistence;
using DailyDinner.Domain.Entities;

namespace DailyDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository 
{
    private static readonly List<User> _users = new();
    public void AddUser(User user) {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email) {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}
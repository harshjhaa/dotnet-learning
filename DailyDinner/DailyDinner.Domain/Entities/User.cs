namespace DailyDinner.Domain.Entities;

public class User
{
    public User(string FirstName, string LastName, string Email, string Password)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Email = Email;
        this.Password = Password;
    }

    public Guid Id { get; init; } = Guid.NewGuid();
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
}

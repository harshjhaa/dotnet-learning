using DailyDinner.Application.Common.Interface.Authentication;
using DailyDinner.Application.Common.Interface.Persistence;
using DailyDinner.Domain.Entities;

namespace DailyDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not User user){
            throw new Exception("User not found");
        }

        if(user.Password != password)
        {
            throw new Exception("User not found");
        }

        //Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check if user exists
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User already exists");
        }

        //Create the user (generate unique id) and Persist to DB
        var user = new User(
            FirstName: firstName,
            LastName: lastName,
            Email: email,
            Password: password
        );

        _userRepository.AddUser(user);

        //Create JWT Token

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
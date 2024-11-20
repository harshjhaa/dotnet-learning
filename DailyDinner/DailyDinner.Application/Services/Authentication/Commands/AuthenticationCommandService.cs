using DailyDinner.Application.Common.Errors;
using DailyDinner.Application.Common.Interface.Authentication;
using DailyDinner.Application.Common.Interface.Persistence;
using DailyDinner.Application.Services.Authentication.Common;
using DailyDinner.Domain.Entities;

namespace DailyDinner.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check if user exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new DuplicateEmailExceptions();
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
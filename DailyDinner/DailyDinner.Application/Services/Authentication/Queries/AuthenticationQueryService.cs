using DailyDinner.Application.Common.Errors;
using DailyDinner.Application.Common.Interface.Authentication;
using DailyDinner.Application.Common.Interface.Persistence;
using DailyDinner.Application.Services.Authentication.Common;
using DailyDinner.Domain.Entities;

namespace DailyDinner.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User not found");
        }

        if (user.Password != password)
        {
            throw new Exception("User not found");
        }

        //Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
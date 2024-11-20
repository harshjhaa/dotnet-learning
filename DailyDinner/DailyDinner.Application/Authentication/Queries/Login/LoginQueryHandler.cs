using DailyDinner.Application.Authentication.Commands.Login;
using DailyDinner.Application.Common.Interface.Authentication;
using DailyDinner.Application.Common.Interface.Persistence;
using DailyDinner.Application.Services.Authentication.Common;
using DailyDinner.Domain.Entities;
using MediatR;

namespace DailyDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            throw new Exception("User not found");
        }

        if (user.Password != query.Password)
        {
            throw new Exception("User not found");
        }

        //Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
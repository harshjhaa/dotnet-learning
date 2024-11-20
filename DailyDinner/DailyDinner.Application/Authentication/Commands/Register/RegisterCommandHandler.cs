using DailyDinner.Application.Common.Errors;
using DailyDinner.Application.Common.Interface.Authentication;
using DailyDinner.Application.Common.Interface.Persistence;
using DailyDinner.Application.Services.Authentication.Common;
using DailyDinner.Domain.Entities;
using MediatR;

namespace DailyDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        //Check if user exists
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            throw new DuplicateEmailExceptions();
        }

        //Create the user (generate unique id) and Persist to DB
        var user = new User(
            FirstName: command.FirstName,
            LastName: command.LastName,
            Email: command.Email,
            Password: command.Password
        );

        _userRepository.AddUser(user);

        //Create JWT Token

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
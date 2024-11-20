using Microsoft.AspNetCore.Mvc;
using DailyDinner.Contracts.Authentication;
using MediatR;
using DailyDinner.Application.Services.Authentication.Common;
using DailyDinner.Application.Authentication.Commands.Register;
using DailyDinner.Application.Authentication.Commands.Login;

namespace DailyDinner.Api.Controllers;

[ApiController]
[Route("auth")]

public class AuthenticationController : ControllerBase
{
    private readonly ISender _mediator;
    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        
        AuthenticationResult authResult = await _mediator.Send(command);

        // return authResult.Match(
        //     authResult => Ok(MapAuthResult(authResult)),
        //     errors => Problem(errors));

        return Ok(authResult);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if (request == null)
        {
            return BadRequest("Request is null");
        }

        var query = new LoginQuery(request.Email, request.Password);

        var authResult = await _mediator.Send(query);

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);

        return Ok(response);
    }
}
using Microsoft.AspNetCore.Mvc;
using DailyDinner.Contracts.Authentication;
using DailyDinner.Application.Services.Authentication.Commands;
using DailyDinner.Application.Services.Authentication.Queries;
using MediatR;

namespace DailyDinner.Api.Controllers;

[ApiController]
[Route("auth")]

public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IAuthenticationCommandService _authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryService;

    public AuthenticationController(
        IAuthenticationCommandService authenticationCommandService, 
        IAuthenticationQueryService authenticationQueryService)
    {
        ArgumentNullException.ThrowIfNull(authenticationCommandService);
        ArgumentNullException.ThrowIfNull(authenticationQueryService);
        _authenticationCommandService = authenticationCommandService;
        _authenticationQueryService = authenticationQueryService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        if (request == null)
        {
            return BadRequest("Request is null");
        }

        var authResult = _authenticationCommandService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        if (request == null)
        {
            return BadRequest("Request is null");
        }

        var authResult = _authenticationQueryService.Login(
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);

        return Ok(response);
    }
}
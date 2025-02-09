using Authentication.API.Requests;
using Authentication.API.Services.Interfaces;
using Authentication.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.API.Controllers;

[ApiController]
[Route("v1/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("log-in")]
    public async Task<ActionResult<TokenResponseModel>> LogIn([FromBody] LogInRequest request)
    {
        var result = await _authService.LogIn(request);

        if (result is null)
            return UnprocessableEntity("Credentials not found or incorrect");

        return Ok(result);
    }

    [HttpPost("sign-up")]
    public async Task<ActionResult<string>> SignUp([FromBody] SignUpRequest request)
    {
        var result = await _authService.SignUp(request);

        if (!result)
            return UnprocessableEntity("User already exists");

        return Ok(result);
    }
}

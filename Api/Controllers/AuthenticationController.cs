using Api.Filters;
using Application.Services.Authentication;
using Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ErrorHandlingFilter]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            var authResult = _authenticationService.Register(
                registerRequest.FirstName,
                registerRequest.LastName,
                registerRequest.Email,
                registerRequest.Password);

            var response = new AuthenticationResponse(
                authResult.user.Id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.token
                );

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var authResult = _authenticationService.Login(
                loginRequest.Email,
                loginRequest.Password);

            var response = new AuthenticationResponse(
                authResult.user.Id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.token
                );

            return Ok(response);
        }
    }
}
using Application.Authentication.Commands.Register;
using Application.Authentication.Queries.Login;
using Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var command = _mapper.Map<RegisterCommand>(registerRequest);
            
            var authResult = await _mediator.Send(command);

            var response = _mapper.Map<AuthenticationResponse>(authResult);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {

            var query = _mapper.Map<LoginQuery>(loginRequest);
            var authResult = await _mediator.Send(query);

            var response = _mapper.Map<AuthenticationResponse>(authResult);

            return Ok(response);
        }
    }
}
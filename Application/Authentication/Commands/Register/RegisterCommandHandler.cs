using Application.Services.Authentication.Commands;
using Application.Services.Authentication.Common;
using Application.Services.Authentication.Queries;
using MediatR;

namespace Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IAuthenticationCommandService _authenticationCommandService;

        public RegisterCommandHandler(IAuthenticationCommandService authenticationCommandService)
        {
            _authenticationCommandService = authenticationCommandService;
        }

        public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result = _authenticationCommandService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            return result;
        }
    }
}
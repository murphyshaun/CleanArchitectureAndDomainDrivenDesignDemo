using Application.Services.Authentication.Common;
using Application.Services.Authentication.Queries;
using MediatR;

namespace Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IAuthenticationQueryService _authenticationQueryService;

        public LoginQueryHandler(IAuthenticationQueryService authenticationQueryService)
        {
            _authenticationQueryService = authenticationQueryService;
        }
        public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var result = _authenticationQueryService.Login(request.Email, request.Password);

            return result;
        }
    }
}
using Application.Services.Authentication.Common;
using MediatR;

namespace Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<AuthenticationResult>;
}
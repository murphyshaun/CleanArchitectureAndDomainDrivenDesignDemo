using Application.Services.Authentication.Common;
using MediatR;

namespace Application.Authentication.Commands.Queries.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<AuthenticationResult>;
}
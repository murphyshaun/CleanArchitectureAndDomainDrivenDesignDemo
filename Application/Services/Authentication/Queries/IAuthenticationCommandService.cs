using Application.Services.Authentication.Common;
using OneOf;

namespace Application.Services.Authentication.Queries
{
    public interface IAuthenticationQueryService
    {
        AuthenticationResult Login(
            string email,
            string password);
    }
}
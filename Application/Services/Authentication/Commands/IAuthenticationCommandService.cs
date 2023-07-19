using Application.Services.Authentication.Common;
using OneOf;

namespace Application.Services.Authentication.Commands
{
    public interface IAuthenticationCommandService
    {
        AuthenticationResult Register(
            string firstName,
            string lastName,
            string email,
            string password);
    }
}
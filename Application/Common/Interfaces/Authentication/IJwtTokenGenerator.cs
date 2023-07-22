using Domain.UserAggregate;

namespace Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GeneratorToken(User user);
    }
}
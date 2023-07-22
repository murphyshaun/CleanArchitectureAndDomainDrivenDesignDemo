using Application.Common.Errors;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Services.Authentication.Common;
using Domain.UserAggregate;

namespace Application.Services.Authentication.Queries
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationQueryService(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {
            //Validate the user exists
            if (_userRepository.GetUserByEmail(email) is not User user)
                throw new Exception("User with given email does not exists.");


            //Validate the password is correct
            if (user.Password != password)
                throw new Exception("Invalid password.");

            //Create JWT token
            var token = _jwtTokenGenerator.GeneratorToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
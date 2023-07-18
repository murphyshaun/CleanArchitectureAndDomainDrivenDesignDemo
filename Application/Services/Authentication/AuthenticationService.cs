using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;

namespace Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(
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
            if(user.Password != password)
                throw new Exception("Invalid password.");

            //Create JWT token
            var token = _jwtTokenGenerator.GeneratorToken(user);

            return new AuthenticationResult(
                user,
                token);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            //Check if user already exists
            if (_userRepository.GetUserByEmail(email) is not null)
                throw new Exception("User with give email already exists.");

            //Create user (generate unique id) & Persist to DB
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.Add(user);

            //Create JWT token
            var token = _jwtTokenGenerator.GeneratorToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
﻿using Application.Common.Interfaces.Authentication;

namespace Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResult Login(string email, string password)
        {
            

            return new AuthenticationResult(
                Guid.NewGuid(),
                "firstname",
                "lastname",
                email,
                "token");
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {

            //Check if user already exists

            //Create user (generate unique id)
            var userId = Guid.NewGuid();

            //Create JWT token
            var token = _jwtTokenGenerator.GeneratorToken(userId, firstName, lastName);

            return new AuthenticationResult(
                Guid.NewGuid(),
                firstName,
                lastName,
                email,
                token);
        }
    }
}
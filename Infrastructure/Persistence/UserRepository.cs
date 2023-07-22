using Application.Common.Interfaces.Persistence;
using Domain.UserAggregate;

namespace Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _user = new();

        public void Add(User user)
        {
            _user.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _user.SingleOrDefault(c => c.Email.Equals(email));
        }
    }
}
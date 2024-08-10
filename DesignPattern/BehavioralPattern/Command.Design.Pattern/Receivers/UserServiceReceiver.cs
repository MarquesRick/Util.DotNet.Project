using Command.Design.Pattern.Entities;

namespace Command.Design.Pattern.Receivers
{
    public class UserServiceReceiver
    {
        private readonly Dictionary<int, User> _users = [];

        public void InsertUser(User user)
        {
            _users[user.Id] = user;
            Console.WriteLine($"User {user.Name} inserted.");
        }

        public void UpdateUser(User user)
        {
            _users[user.Id] = user;
            Console.WriteLine($"User {user.Name} updated.");
        }

        public void DeleteUser(int userId)
        {
            _users.Remove(userId);
            Console.WriteLine($"User with ID {userId} deleted.");
        }

        public User GetUserById(int userId)
        {
            _users.TryGetValue(userId, out var user);
            return user;
        }
    }
}

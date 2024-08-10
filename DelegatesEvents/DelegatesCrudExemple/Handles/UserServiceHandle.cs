using DelegatesCrudExemple.Entities;
using DelegatesCrudExemple.Events;

namespace DelegatesCrudExemple.Handles
{
    public class UserServiceHandle
    {
        // Define the delegate
        public delegate void UserEventHandler(object sender, UserEventArgs e);

        // Define the events
        public event UserEventHandler UserValidating;

        private readonly Dictionary<int, User> _users = new Dictionary<int, User>();

        // Method to invoke validation
        protected virtual void OnUserValidating(UserEventArgs e)
        {
            UserValidating?.Invoke(this, e);
        }

        // Insert user
        public void InsertUser(User user)
        {
            var args = new UserEventArgs(user);
            OnUserValidating(args);

            if (args.IsValid)
            {
                _users[user.Id] = user;
                Console.WriteLine($"User {user.Name} inserted.");
            }
            else
            {
                Console.WriteLine($"Failed to insert user: {args.ErrorMessage}");
            }
        }

        // Update user
        public void UpdateUser(User user)
        {
            var args = new UserEventArgs(user);
            OnUserValidating(args);

            if (args.IsValid)
            {
                _users[user.Id] = user;
                Console.WriteLine($"User {user.Name} updated.");
            }
            else
            {
                Console.WriteLine($"Failed to update user: {args.ErrorMessage}");
            }
        }

        // Delete user
        public void DeleteUser(int userId)
        {
            if (_users.ContainsKey(userId))
            {
                _users.Remove(userId);
                Console.WriteLine($"User with ID {userId} deleted.");
            }
            else
            {
                Console.WriteLine($"User with ID {userId} does not exist.");
            }
        }

        // Get user by ID
        public User GetUserById(int userId)
        {
            _users.TryGetValue(userId, out var user);
            return user;
        }
    }
}

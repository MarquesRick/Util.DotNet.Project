using DelegatesCrudExemple.Entities;
using DelegatesCrudExemple.Validator;

namespace DelegatesCrudExemple.Handles
{
    public class UserServiceHandle
    {
        private readonly UserValidator _userValidator = new UserValidator();
        private readonly List<User> _users = new List<User>();

        public UserServiceHandle()
        {
            _userValidator.UserValidation += OnUserValidation;
        }

        public void InsertUser(User user)
        {
            _userValidator.ValidateUser(user);
            _users.Add(user);
            Console.WriteLine($"User {user.Name} inserted.");
        }

        public void UpdateUser(User user)
        {
            _userValidator.ValidateUser(user);
            var existingUser = _users.Find(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                Console.WriteLine($"User {user.Name} updated.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public void DeleteUser(int userId)
        {
            var user = _users.Find(u => u.Id == userId);
            if (user != null)
            {
                _users.Remove(user);
                Console.WriteLine($"User {user.Name} deleted.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        private void OnUserValidation(object sender, ValidationEventArgs e)
        {
            Console.WriteLine($"Validation Error: {e.Message}");
        }
    }
}

using DelegatesCrudExemple.Events;
using DelegatesCrudExemple.Handles;

namespace DelegatesCrudExemple.Validator
{
    public class UserValidator
    {
        public void ValidateUser(object sender, UserEventArgs e)
        {
            //sender used to obtain more information about the service that identifies the source of the event
            var userService = sender as UserServiceHandle;
            if (userService != null)
            {
                Console.WriteLine($"Validation performed by: {userService.ServiceName}");
            }

            if (string.IsNullOrWhiteSpace(e.User.Name))
            {
                e.IsValid = false;
                e.ErrorMessage = "User name cannot be empty.";
            }
            else if (string.IsNullOrWhiteSpace(e.User.Email) || !e.User.Email.Contains("@"))
            {
                e.IsValid = false;
                e.ErrorMessage = "Invalid email address.";
            }
        }
    }
}

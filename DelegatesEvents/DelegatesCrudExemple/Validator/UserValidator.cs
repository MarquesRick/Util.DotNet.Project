using DelegatesCrudExemple.Events;

namespace DelegatesCrudExemple.Validator
{
    public class UserValidator
    {
        public void ValidateUser(object sender, UserEventArgs e)
        {
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

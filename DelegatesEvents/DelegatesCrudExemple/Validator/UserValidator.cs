using DelegatesCrudExemple.Entities;

namespace DelegatesCrudExemple.Validator
{
    public class UserValidator
    {
        public delegate void ValidationHandler(object sender, ValidationEventArgs e);

        public event ValidationHandler UserValidation;

        protected virtual void OnUserValidation(ValidationEventArgs e)
        {
            UserValidation?.Invoke(this, e);
        }

        public void ValidateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                OnUserValidation(new ValidationEventArgs("User name cannot be empty."));
            }

            if (!IsValidEmail(user.Email))
            {
                OnUserValidation(new ValidationEventArgs("User email is invalid."));
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

    public class ValidationEventArgs : EventArgs
    {
        public string Message { get; }

        public ValidationEventArgs(string message)
        {
            Message = message;
        }
    }

}

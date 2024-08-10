using DelegatesCrudExemple.Entities;

namespace DelegatesCrudExemple.Events
{
    public class UserEventArgs : EventArgs
    {
        public User User { get; set; }
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        public UserEventArgs(User user)
        {
            User = user;
            IsValid = true;
        }
    }
}

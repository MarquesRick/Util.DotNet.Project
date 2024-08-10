using Command.Design.Pattern.Entities;
using Command.Design.Pattern.Enums;
using Command.Design.Pattern.Interfaces;
using Command.Design.Pattern.Receivers;

namespace Command.Design.Pattern.Commands
{
    public class UpdateUserCommand : ICommand
    {
        private readonly UserServiceReceiver _userService;
        private readonly User _user;
        private User _oldUser;
        public string Name => Enum.GetName(typeof(ProcessType), ProcessType.Update);
        public UpdateUserCommand(UserServiceReceiver userService, User user)
        {
            _userService = userService;
            _user = user;
        }

        public void Execute()
        {
            _oldUser = _userService.GetUserById(_user.Id);
            _userService.UpdateUser(_user);
        }

        public void Undo()
        {
            _userService.UpdateUser(_oldUser);
        }
    }
}

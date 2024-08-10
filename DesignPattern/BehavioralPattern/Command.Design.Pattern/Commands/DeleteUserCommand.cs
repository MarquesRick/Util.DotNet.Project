using Command.Design.Pattern.Entities;
using Command.Design.Pattern.Enums;
using Command.Design.Pattern.Interfaces;
using Command.Design.Pattern.Receivers;

namespace Command.Design.Pattern.Commands
{
    public class DeleteUserCommand : ICommand
    {
        private readonly UserServiceReceiver _userService;
        private readonly int _userId;
        private User _deletedUser;

        public string Name => Enum.GetName(typeof(ProcessType), ProcessType.Delete);

        public DeleteUserCommand(UserServiceReceiver userService, int userId)
        {
            _userService = userService;
            _userId = userId;
        }

        public void Execute()
        {
            _deletedUser = _userService.GetUserById(_userId);
            _userService.DeleteUser(_userId);
        }

        public void Undo()
        {
            if (_deletedUser != null)
            {
                _userService.InsertUser(_deletedUser);
            }
        }
    }
}

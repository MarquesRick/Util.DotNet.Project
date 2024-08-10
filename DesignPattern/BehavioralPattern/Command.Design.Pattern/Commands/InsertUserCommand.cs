using Command.Design.Pattern.Entities;
using Command.Design.Pattern.Enums;
using Command.Design.Pattern.Interfaces;
using Command.Design.Pattern.Receivers;

namespace Command.Design.Pattern.Commands
{
    public class InsertUserCommand : ICommand
    {
        private readonly UserServiceReceiver _userService;
        private readonly User _user;

        public InsertUserCommand(UserServiceReceiver userService, User user)
        {
            _userService = userService;
            _user = user;
        }

        public string Name => Enum.GetName(typeof(ProcessType), ProcessType.Insert);

        public void Execute()
        {
            _userService.InsertUser(_user);
        }

        public void Undo()
        {
            _userService.DeleteUser(_user.Id);
        }
    }
}

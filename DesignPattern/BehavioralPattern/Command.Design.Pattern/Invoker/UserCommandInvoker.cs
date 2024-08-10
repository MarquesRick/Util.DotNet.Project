using Command.Design.Pattern.Enums;
using Command.Design.Pattern.Interfaces;

namespace Command.Design.Pattern.Invoker
{
    public class UserCommandInvoker : IInvoker<ICommand, IState>
    {
        private readonly Stack<ICommand> _commandHistory = new();

        public IState ExecuteCommand(ICommand command)
        {
            Console.WriteLine($"\nExecuting command: {command.Name}.");
            command.Execute();
            _commandHistory.Push(command);
            return new State((int)Enum.Parse(typeof(ProcessType), command.Name), command.Name);
        }

        public IState UndoLastCommand()
        {
            if (_commandHistory.Count > 0)
            {
                ICommand command = _commandHistory.Pop();
                Console.WriteLine($"\nExecuting undoing command: {command.Name}.");
                command.Undo();
                return new State(0, $"Undoing command: {command.Name}.");
            }

            return new State(-1, $"Not to undoing.");
        }
    }
}

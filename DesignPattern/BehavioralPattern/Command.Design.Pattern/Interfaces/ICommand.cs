namespace Command.Design.Pattern.Interfaces
{
    public interface ICommand
    {
        string Name { get; }
        void Execute();
        void Undo();
    }
}
namespace Command.Design.Pattern.Interfaces
{
    //in -> input
    //out -> output
    public interface IInvoker<in T, out O>
        where T : ICommand //input
        where O : IState //output
    {
        IState ExecuteCommand(T command);

        IState UndoLastCommand();
    }
}

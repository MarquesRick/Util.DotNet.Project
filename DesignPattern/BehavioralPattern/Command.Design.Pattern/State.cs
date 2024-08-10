using Command.Design.Pattern.Interfaces;

namespace Command.Design.Pattern
{
    public class State : IState
    {
        public State(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}

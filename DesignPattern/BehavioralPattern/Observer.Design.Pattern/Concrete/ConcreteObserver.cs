using Observer.Design.Pattern.Interfaces;

namespace Observer.Design.Pattern.Concrete
{
    public class ConcreteObserver : IObserver
    {
        public string User { get; set; }
        public ConcreteObserver(string name, ISubject subject)
        {
            User = name;
            subject.RegisterObserver(this);
        }

        public void Update(string availability)
        {
            Console.WriteLine($"Hello {User}, The product you want is now " +
               $"{availability} on our website");
        }
    }
}

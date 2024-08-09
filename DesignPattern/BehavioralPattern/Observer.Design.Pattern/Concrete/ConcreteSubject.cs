using Observer.Design.Pattern.Interfaces;

namespace Observer.Design.Pattern.Concrete
{
    public class ConcreteSubject : ISubject
    {
        private List<IObserver> _observers = [];
        private string Product { get; set; }
        private int Price { get; set; }
        private string Availability { get; set; }
        public ConcreteSubject(string product,
            int price,
            string availability)
        {
            Product = product;
            Price = price;
            Availability = availability;
        }

        public string GetAvailability()
        {
            return Availability;
        }
        public void SetAvailability(string status)
        {
            this.Availability = status;
            Console.WriteLine("Availability has changed from 'Out of Stock' to 'Available'.");
            NotifyObservers();
        }
        public void RegisterObserver(IObserver observer)
        {
            Console.WriteLine("Observer Added : " + ((ConcreteObserver)observer).User);
            _observers.Add(observer);
        }
        public void AddObservers(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            Console.WriteLine($"The product :{Product} for R$ {Price} is now available."
                + "\n### Notifying all registered Observers");

            Console.WriteLine();

            foreach (IObserver observer in _observers)
                observer.Update(Availability);
        }

    }
}

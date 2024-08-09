using Observer.Design.Pattern.Concrete;

ConcreteSubject IPhone11 = new ConcreteSubject("iPhone 11 ", 4900, "Out of Stock");
Console.WriteLine("iPhone 11 - Current Status : " + IPhone11.GetAvailability());

Console.WriteLine("\nObservers subscribed to receive notifications about " +
    "the product iPhone 11\n");

ConcreteObserver john = new("John", IPhone11);
ConcreteObserver mary = new("Mary", IPhone11);
ConcreteObserver betty = new("Betty", IPhone11);

Console.WriteLine("\nPress something to change availability and notify observers\n");
Console.ReadKey();

//altera status do Subject e notifica observers
IPhone11.SetAvailability("Available");

Console.Read();
using Facade.Design.Pattern.Facade;

var facade = new RestaurantFacade();
Console.WriteLine("CUSTOMER PIZZA ORDERS");
facade.GetNormalPizza();
facade.GetVeganPizza();

Console.WriteLine("\nCUSTOMER BREAD ORDERS");
facade.GetGarlicBread();
facade.GetCheeseGarlicBread();
using Decorator.Design.Pattern.Component;
using Decorator.Design.Pattern.ConcreteComponent;
using Decorator.Design.Pattern.ConcreteDecorator;

IVehicle vehicle = new Vehicle();

Console.WriteLine(vehicle.Optional());
Console.WriteLine($"Price R$ {vehicle.Price()}\n");
Console.WriteLine("Enter any button to set optionals");
Console.ReadKey();

Console.WriteLine("------ Applying Decorator ------------------");

IVehicle vehicle2 = new Vehicle();
IVehicle specialTireDecorator = new SpecialTireDecorator(vehicle2);
IVehicle premiumSoundDecorator = new PremiumSoundSystemDecorator(specialTireDecorator);
IVehicle premiumColorDecorator = new PremiumColorDecorator(premiumSoundDecorator);

Console.WriteLine(premiumColorDecorator.Optional());
Console.WriteLine($"Total Price R$ : {premiumColorDecorator.Price()}\n");
Console.ReadKey();

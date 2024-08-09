using FactoryMethod.Design.Pattern.ConcreteCreator;
using FactoryMethod.Design.Pattern.Creator;
using FactoryMethod.Design.Pattern.Product;
using System.Text.Json;

try
{
    CardFactory cardFactory = null;
    Console.WriteLine("Enter card type");
    var console = Console.ReadLine();

    cardFactory = console?.ToLower() switch
    {
        "black" => new BlackFactory(50000, 0),
        "titanium" => new TitaniumFactory(100000, 500),
        "platinum" => new PlatinumFactory(500000, 1000),
        _ => throw new NotImplementedException()
    };

    CreditCard creditCard = cardFactory.GetCreditCard();
    Console.WriteLine("\nFollow the card selected\n");
    Console.WriteLine(JsonSerializer.Serialize(creditCard));
    Console.ReadKey();
}
catch (NotImplementedException)
{
    Console.WriteLine("\nUnknown card type. Please select another card\n");
}
catch (Exception)
{
    Console.WriteLine("\nUnknown error. Contact the developer\n");
}
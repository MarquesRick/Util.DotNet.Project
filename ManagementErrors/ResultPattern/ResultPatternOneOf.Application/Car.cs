namespace ResultPatternOneOf.Application;

public class Car
{
    public Car(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }

    //for EF
    private Car() { }
}

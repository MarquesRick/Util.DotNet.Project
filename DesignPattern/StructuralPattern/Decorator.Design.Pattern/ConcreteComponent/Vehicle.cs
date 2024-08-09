using Decorator.Design.Pattern.Component;

namespace Decorator.Design.Pattern.ConcreteComponent
{
    public class Vehicle : IVehicle
    {
        public string Optional()
        {
            return $"Car base created";
        }

        public decimal Price()
        {
            return 100000M;
        }
    }
}

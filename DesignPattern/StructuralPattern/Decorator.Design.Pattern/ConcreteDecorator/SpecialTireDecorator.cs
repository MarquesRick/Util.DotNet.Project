using Decorator.Design.Pattern.Component;
using Decorator.Design.Pattern.Decorator;

namespace Decorator.Design.Pattern.ConcreteDecorator
{
    public class SpecialTireDecorator : VehicleDecorator
    {
        public SpecialTireDecorator(IVehicle vehicle)
            : base(vehicle)
        { }

        public override decimal PriceValue { get => 500M; }

        public override string Optional()
        {
            var vehicle = base.Optional();
            vehicle += $"\r\n Chosen with special tires -> {this.PriceValue}";
            return vehicle;
        }

        public override decimal Price()
        {
            var price = base.Price();
            price += this.PriceValue;
            return price;
        }
    }
}

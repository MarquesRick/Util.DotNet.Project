using Decorator.Design.Pattern.Component;
using Decorator.Design.Pattern.Decorator;

namespace Decorator.Design.Pattern.ConcreteDecorator
{
    public class PremiumSoundSystemDecorator : VehicleDecorator
    {
        public PremiumSoundSystemDecorator(IVehicle vehicle)
            : base(vehicle)
        { }

        public override decimal PriceValue { get => 3000M; }

        public override string Optional()
        {
            var optional = base.Optional();
            return optional
                += $"\r\n Chosen with Premium Sound System -> {this.PriceValue}";
        }

        public override decimal Price()
        {
            var price = base.Price();
            return price += this.PriceValue;
        }
    }
}

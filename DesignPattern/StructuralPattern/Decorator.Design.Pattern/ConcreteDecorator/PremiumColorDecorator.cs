using Decorator.Design.Pattern.Component;
using Decorator.Design.Pattern.Decorator;

namespace Decorator.Design.Pattern.ConcreteDecorator
{
    public class PremiumColorDecorator : VehicleDecorator
    {
        public PremiumColorDecorator(IVehicle vehicle)
            : base(vehicle)
        { }

        public override decimal PriceValue { get => 2000M; }

        public override string Optional()
        {
            var optional = base.Optional();
            return optional
                += $"\r\n Chosen Premium Color -> {this.PriceValue}";
        }

        public override decimal Price()
        {
            var price = base.Price();
            return price += this.PriceValue;
        }
    }
}

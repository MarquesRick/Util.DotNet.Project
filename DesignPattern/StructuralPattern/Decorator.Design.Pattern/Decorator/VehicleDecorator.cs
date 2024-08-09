using Decorator.Design.Pattern.Component;

namespace Decorator.Design.Pattern.Decorator
{
    public class VehicleDecorator : IVehicle
    {
        private readonly IVehicle _vehicle;
        public VehicleDecorator(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }
        public virtual string Optional()
        {
            return _vehicle.Optional();
        }

        public virtual decimal Price()
        {
            return _vehicle.Price();
        }

        public virtual decimal PriceValue { get; set; }
    }
}

using Facade.Design.Pattern.Implementation;
using Facade.Design.Pattern.Interfaces;

namespace Facade.Design.Pattern.Facade
{
    public class RestaurantFacade
    {
        private IPizza _pizzaSupplier;
        private IBread _breadSupplier;

        public RestaurantFacade()
        {
            _pizzaSupplier = new PizzaSupplier();
            _breadSupplier = new BreadSupplier();
        }

        public void GetNormalPizza() => _pizzaSupplier.GetPizza();

        public void GetVeganPizza() => _pizzaSupplier.GetVeganPizza();

        public void GetGarlicBread() => _breadSupplier.GetGarlicBread();

        public void GetCheeseGarlicBread() => _breadSupplier.GetGarlicBreadWithCheese();
    }
}

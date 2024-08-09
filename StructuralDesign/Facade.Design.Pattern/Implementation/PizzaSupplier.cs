using Facade.Design.Pattern.Interfaces;

namespace Facade.Design.Pattern.Implementation
{
    public class PizzaSupplier : IPizza
    {
        public void GetPizza()
        {
            GetNonVeganPizzaTopping();
            Console.WriteLine("Getting normal pizza");
        }

        public void GetVeganPizza()
        {
            Console.WriteLine("Getting vegan pizza");
        }

        private void GetNonVeganPizzaTopping() => Console.WriteLine("Getting non vegan pizza topping ");
    }
}

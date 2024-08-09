using Facade.Design.Pattern.Interfaces;

namespace Facade.Design.Pattern.Implementation
{
    public class BreadSupplier : IBread
    {
        public void GetGarlicBread()
            => Console.WriteLine("Getting garlic bread");

        public void GetGarlicBreadWithCheese()
        {
            GetCheese();
            Console.WriteLine("Getting garlic bread with cheese");
        }

        private void GetCheese() 
            => Console.WriteLine("Getting cheese");
    }
}

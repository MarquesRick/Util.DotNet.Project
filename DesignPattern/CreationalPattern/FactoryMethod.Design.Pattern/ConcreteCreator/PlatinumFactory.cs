using FactoryMethod.Design.Pattern.ConcreteProduct;
using FactoryMethod.Design.Pattern.Creator;
using FactoryMethod.Design.Pattern.Product;

namespace FactoryMethod.Design.Pattern.ConcreteCreator
{
    public class PlatinumFactory : CardFactory
    {
        private decimal _limit;
        private int _annualCharge;

        public PlatinumFactory(decimal limit, int annualCharge)
        {
            this._limit = limit;
            this._annualCharge = annualCharge;
        }
        public override CreditCard GetCreditCard()
            => new PlatinumCard(_limit, _annualCharge);
    }
}

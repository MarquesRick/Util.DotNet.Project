using FactoryMethod.Design.Pattern.ConcreteProduct;
using FactoryMethod.Design.Pattern.Creator;
using FactoryMethod.Design.Pattern.Product;

namespace FactoryMethod.Design.Pattern.ConcreteCreator
{
    public class BlackFactory : CardFactory
    {
        private decimal _limit;
        private int _annualCharge;

        public BlackFactory(decimal limit, int annualCharge)
        {
            this._limit = limit;
            this._annualCharge = annualCharge;
        }
        public override CreditCard GetCreditCard()
            => new BlackCard(_limit, _annualCharge);
    }
}

using FactoryMethod.Design.Pattern.Product;

namespace FactoryMethod.Design.Pattern.Creator
{
    public abstract class CardFactory
    {
        public abstract CreditCard GetCreditCard();
    }
}

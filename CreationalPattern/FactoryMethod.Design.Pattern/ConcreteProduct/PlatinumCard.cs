using FactoryMethod.Design.Pattern.Product;

namespace FactoryMethod.Design.Pattern.ConcreteProduct
{
    public class PlatinumCard : CreditCard
    {
        private readonly string _type;
        private decimal _limit;
        private int _annualCharge;

        public PlatinumCard(decimal limit, int annualCharge)
        {
            this._limit = limit;
            this._annualCharge = annualCharge;
            this._type = "Platinum";
        }

        public override string Type
        {
            get => _type;
        }

        public override decimal Limit
        {
            get => _limit;
            set => _limit = value;
        }
        public override int AnnualCharge
        {
            get => _annualCharge;
            set => _annualCharge = value;
        }
    }
}

using Commandos.Enums;
using Commandos.Models.Products.General;
using Commandos.Models.Products.MeatProduct;

namespace Commandos.AbstractMethod.Factories
{
    internal class MeatFactory : AbstractMethod
    {
        private DateTime _expirationTime;
        private MeatSpecies _meatSpecies;
        private MeatCategory _meatCategory;

        public DateTime ExpirationTime { get; set; }

        public MeatSpecies MeatSpecies { get; set; }

        public MeatCategory MeatCategory { get; set; }

        public MeatFactory()
        {

        }

        public MeatFactory(string name, double price, double weight, DateTime expirationTime, MeatSpecies species, MeatCategory category)
            : base(name, price, weight)
        {
            _expirationTime = expirationTime > DateTime.Now ? expirationTime : DateTime.Now;
        }

        public override IProduct CreateProduct()
        {
            return new MeatProductModel(_name, _price, _weight, _expirationTime, _meatSpecies, _meatCategory);
        }
    }
}

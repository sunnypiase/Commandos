using Commandos.Models.Products.DairyProduct;
using Commandos.Models.Products.General;


namespace Commandos.AbstractMethod.Factories
{
    public class DairyProductFactory : AbstractMethod
    {
        private DateTime _expirationTime;

        public DateTime ExpirationTime { get; set; }

        public DairyProductFactory()
        {

        }

        public DairyProductFactory(string name, double price, double weight, DateTime expirationTime)
            : base(name, price, weight)
        {
            _expirationTime = expirationTime > DateTime.Now ? expirationTime : DateTime.Now;
        }

        public override IProduct CreateProduct() => new DairyProductModel(_name, _price, _weight, _expirationTime);
    }
}

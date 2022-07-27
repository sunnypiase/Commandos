using Commandos.Enums;
using Commandos.Models.Products.CementProduct;
using Commandos.Models.Products.General;

namespace Commandos.AbstractMethod.Factories
{
    class CementFactory : AbstractMethod
    {
        private CementBrand _cementBrand;

        public CementBrand CementBrandProp { get; set; }

        public CementFactory()
        {

        }

        public CementFactory(string name, double price, double weight, CementBrand cementBrand)
            : base(name, price, weight) => _cementBrand = cementBrand;


        public override IProduct CreateProduct() => new CementProductModel(_name, _price, _weight, _cementBrand);
    }
}

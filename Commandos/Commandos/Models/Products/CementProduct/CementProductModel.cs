using Commandos.Enums;
using Commandos.Models.Products.General.IndustrialProduct;
using System.Runtime.Serialization;

namespace Commandos.Models.Products.CementProduct
{
    [DataContract]
    internal class CementProductModel : IndustrialProductBase, ICementProduct
    {
        [DataMember(Name ="CementBrand")]
        public CementBrand CementBrand { get; set; }
        public CementProductModel() :
            this(default, default, default, default)
        { }

        public CementProductModel(string name, double price, double weight, CementBrand cementBrand) : base(name, price, weight)
        {
            this.CementBrand = cementBrand;
        }
        public CementProductModel(CementProductModel other) :
            this(other.Name, other.Price, other.Weight, other.CementBrand)
        { }

        public override object Clone()
        {
            return new CementProductModel(this);
        }
        public override string ToString()
        {
            return base.ToString() + $"Марка Цементу: {CementBrand}; ";
        }
    }
}

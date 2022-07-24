using Commandos.Models.Products.CementProduct;
using Commandos.Models.Products.DairyProduct;
using Commandos.Models.Products.MeatProduct;
using System.Runtime.Serialization;

namespace Commandos.Models.Products.General
{
    [KnownType(typeof(CementProductModel))]
    [KnownType(typeof(DairyProductModel))]
    [KnownType(typeof(MeatProductModel))]
    [DataContract]
    public abstract class ProductBase : IProduct
    {
        protected double _price;
        [DataMember(Name = "Price")]
        public virtual double Price
        {
            get => _price;
            set
            {
                if (_price < 0)
                {
                    throw new ArgumentException();
                }
                _price = value;
            }
        }
        [DataMember(Name = "Name")]
        public virtual string Name { get; set; }
        [DataMember(Name = "ID")]
        public Guid ID { get; set; } = Guid.NewGuid();
        #region Ctors
        protected ProductBase() : this(default, default) { }
        protected ProductBase(string name, double price)
        {
            Name = name;
            Price = price;
        }
        #endregion
        public virtual void ChangePrice(int present)
        {
            Price += _price / 100d * present;
        }
        public virtual int CompareTo(object obj)
        {
            IProduct other = obj as IProduct;
            if (other is null)
            {
                throw (new ArgumentException("wrong object to compare"));
            }
            return ((other.Price).CompareTo(Price));
        }
        public abstract object Clone();

        public override string ToString()
        {
            return $"Назва: {Name}; Ціна: {Price}; ";
        }
    }
}

using Commandos.Models.Products.DairyProduct;
using Commandos.Models.Products.MeatProduct;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Commandos.Models.Products.General.FoodProduct
{
    [KnownType(typeof(DairyProductModel))]
    [KnownType(typeof(MeatProductModel))]
    [DataContract]
    public abstract class FoodProductBase : ProductBase, IFoodProduct
    {
        #region Props

        protected double _weight;
        /*protected SortedDictionary<int, int> _daysToExpirationAndPresentOfChange;*/
        [DataMember(Name = "ExpirationTime")]
        public virtual DateTime ExpirationTime { get; set; }
        [DataMember(Name = "Weight")]
        public virtual double Weight
        {
            get => _weight;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                _weight = value;
            }
        }
        public override double Price
        {
            get => GetPriceByExpiration();
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                _price = value;
            }
        }
        /*[XmlIgnore]
        public virtual SortedDictionary<int, int> DaysToExpirationAndPresentOfChange
        {
            get => new(_daysToExpirationAndPresentOfChange);
            set
            {
                _daysToExpirationAndPresentOfChange = new();
                foreach (KeyValuePair<int, int> item in value)
                {
                    _daysToExpirationAndPresentOfChange.Add(item.Key, item.Value);
                }
            }
        }*/

        #endregion
        #region Ctors
        protected FoodProductBase() : this("", default, default, default/*, default*/)
        {
            /*_daysToExpirationAndPresentOfChange = new SortedDictionary<int, int>();*/
        }

        protected FoodProductBase(string name, double price, double weight, DateTime expirationTime/*, SortedDictionary<int, int> daysToExpirationAndPresentOfChange*/) :
            base(name, price)
        {
            ExpirationTime = expirationTime;
            Weight = weight;
            /*_daysToExpirationAndPresentOfChange = new SortedDictionary<int, int>();
            if (daysToExpirationAndPresentOfChange is not null)
            {
                foreach (KeyValuePair<int, int> item in daysToExpirationAndPresentOfChange)
                {
                    _daysToExpirationAndPresentOfChange.Add(item.Key, item.Value);
                }
            }*/
        }
        #endregion
        #region Methods
        public override int CompareTo(object obj)
        {
            IFoodProduct other = obj as IFoodProduct;
            if (other is null)
            {
                if (obj is IProduct otherProduct)
                {
                    return ((otherProduct.Price).CompareTo(Price));
                }
                throw (new ArgumentException("wrong object to compare"));
            }
            return ((other.Price * other.Weight).CompareTo(Price * Weight));
        }
        public virtual double GetPriceByExpiration()
        {
            int daysToExpiretion = ExpirationTime.Subtract(DateTime.Today).Days;
            /*foreach (KeyValuePair<int, int> item in _daysToExpirationAndPresentOfChange)
            {
                if (daysToExpiretion <= item.Key)
                {
                    return _price - _price * item.Value / 100d;
                }
            }*/
            return _price;
        }
        #endregion
        #region ObjectOverrides
        public override string ToString()
        {
            return base.ToString() + $"Вага: {Weight}; Термін придатності: {ExpirationTime.Date:d}; ";
        }



        #endregion

    }
}

using Commandos.Enums;
using Commandos.Models.Products.General.FoodProduct;

namespace Commandos.Models.Products.MeatProduct
{
    [Serializable]
    public class MeatProductModel : FoodProductBase, IMeatProduct
    {

        #region Props
        public MeatSpecies MeatSpeciesProp { get; set; }
        public MeatCategory MeatCategoryProp { get; set; }

        #endregion
        #region Ctors
        public MeatProductModel() :
            this(default, default, default, default, default, default, default)
        { }

        public MeatProductModel(string name, double price, double weight, DateTime expirationTime, MeatSpecies meatSpecies, MeatCategory meatCategory, SortedDictionary<int, int> daysToExpirationAndPresentOfChange) :
            base(name, price, weight, expirationTime, daysToExpirationAndPresentOfChange)
        {
            MeatSpeciesProp = meatSpecies;
            MeatCategoryProp = meatCategory;
        }

        public MeatProductModel(MeatProductModel other) :
            this(other.Name, other.Price, other.Weight, other.ExpirationTime, other.MeatSpeciesProp, other.MeatCategoryProp, other._daysToExpirationAndPresentOfChange)
        { }

        #endregion
        #region Methods
        public override object Clone()
        {
            return new MeatProductModel(this);
        }


        #endregion
        #region ObjectOverrides
        public override string ToString()
        {
            return base.ToString() + $"Вид м'яса: {MeatSpeciesProp}; Категорія м'яса: {MeatCategoryProp}";
        }



        #endregion


    }
}

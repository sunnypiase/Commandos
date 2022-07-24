using Commandos.Enums;
using Commandos.Models.Products.General.FoodProduct;

namespace Commandos.Models.Products.MeatProduct
{
    public interface IMeatProduct : IFoodProduct
    {
        MeatSpecies MeatSpeciesProp { get; set; }
        MeatCategory MeatCategoryProp { get; set; }
    }
}

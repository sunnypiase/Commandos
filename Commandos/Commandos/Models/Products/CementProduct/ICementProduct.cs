using Commandos.Enums;
using Commandos.Models.Products.General.IndustrialProduct;

namespace Commandos.Models.Products.CementProduct
{
    internal interface ICementProduct : IIndustrialProduct
    {
        CementBrand CementBrand { get; set; }
    }
}

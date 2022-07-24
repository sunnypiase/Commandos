namespace Commandos.Models.Products.General
{
    public interface IPhysicalProduct : IProduct
    {
        public double Weight { get; set; }
    }
}

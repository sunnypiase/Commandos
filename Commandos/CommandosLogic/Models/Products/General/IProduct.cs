namespace Commandos.Models.Products.General
{

    public interface IProduct : IComparable, ICloneable
    {
        double Price { get; set; }
        string Name { get; set; }
        Guid ID { get; set; }//test
        void ChangePrice(int present);
    }
}

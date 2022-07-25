using Commandos.Models.Products.CementProduct;
using Commandos.Models.Products.DairyProduct;
using Commandos.Models.Products.General;
using Commandos.Models.Products.MeatProduct;
using Commandos.User;
using System.Runtime.Serialization;
using System.Text;

namespace Commandos.Models.Carts
{
    [KnownType(typeof(CementProductModel))]
    [KnownType(typeof(DairyProductModel))]
    [KnownType(typeof(MeatProductModel))]
    [DataContract]
    public class Cart
    {
        #region Props
        private Guid id;
        private Dictionary<IProduct, int> cartProducts;
        [DataMember(Name = "ID")]
        public Guid Id { get => id; }
        [DataMember(Name = "CartProducts")]
        public Dictionary<IProduct, int> CartProducts { get => cartProducts; private set => cartProducts = value; }
        #endregion
        #region Ctors
        public Cart(IUser user)
        {
            id = user.Guid;
            cartProducts = new();
        }
        #endregion
        #region Methods
        public void AddProduct(IProduct product, int count)
        {
            if (count <= 0)
            {
                return;
            }
            try
            {
                if (CartProducts.ContainsKey(product))
                {
                    CartProducts[product] += count;
                }
                else
                {
                    CartProducts.Add(product, count);
                }
            }
            catch (Exception ex)
            {
                //Todo add event on bad data or Logger
            }
        }
        public void DeleteProduct(IProduct product, int count)//TODO add event on bad data or Logger
        {
            if (count <= 0)
            {
                return;
            }

            if (!CartProducts.ContainsKey(product))
            {
                return;
            }
            try
            {
                if (CartProducts[product] > count)
                {
                    CartProducts[product] -= count;
                }
                else
                {
                    CartProducts.Remove(product);
                }
            }
            catch (Exception ex)
            {
                //Todo add event on bad data or Logger
            }

        }
        public void ClearCart()
        {
            CartProducts.Clear();
        }
        public double Sum()
        {
            double sum = 0;
            foreach (KeyValuePair<IProduct, int> prod in CartProducts)
            {
                sum += prod.Key.Price + prod.Value;
            }
            return sum;
        }
        #endregion
        #region ObjectOvverrides
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("Products:\n");
            foreach (KeyValuePair<IProduct, int> item in cartProducts)
            {
                stringBuilder.AppendLine($"{item.Key.Name} \t{item.Value} x {item.Key.Price} = {item.Value * item.Key.Price:#.00}");
            }
            stringBuilder.AppendLine($"Total sum : \t{Sum()}");
            return stringBuilder.ToString();
        }
        public override bool Equals(object? obj)
        {
            return Id == (obj as Cart).Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        #endregion
    }
}

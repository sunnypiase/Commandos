using Commandos.Models.Products.General;
using System.Text;

namespace Commandos.Models.Carts
{
    public class Cart
    {
        private string id;//TODO Change id to Guid
        private Dictionary<IProduct, int> cartProducts;
        public string Id => id;
        public Dictionary<IProduct, int> CartProducts { get => cartProducts; private set => cartProducts = value; }

        public Cart(string id)//TODO ctor must get person
        {
            this.id = id;
            cartProducts = new();
        }
        public Cart(string id, Dictionary<IProduct, int> cartProducts) : this(id)//TODO must be deleted
        {
            CartProducts = cartProducts;
        }
        public void AddProduct(IProduct product, int count)//TODO add try
        {
            if (count <= 0)
            {
                return;
            }

            if (CartProducts.ContainsKey(product))
            {
                CartProducts[product] += count;
            }
            else
            {
                CartProducts.Add(product, count);
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

            if (CartProducts[product] > count)
            {
                CartProducts[product] -= count;
            }
            else
            {
                CartProducts.Remove(product);
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
    }
}

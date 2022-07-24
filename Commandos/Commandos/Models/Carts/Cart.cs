using Commandos.Models.Products.General;
using System.Text;

namespace Commandos.Models.Carts
{
    public class Cart
    {
        private string id;
        private Dictionary<IProduct, int> cartProducts;
        public string Id => id;
        public Dictionary<IProduct, int> CartProducts { get => cartProducts; private set => cartProducts = value; }

        public Cart(string id)
        {
            this.id = id;
            cartProducts = new();
        }
        public Cart(string id, Dictionary<IProduct, int> cartProducts) : this(id)
        {
            CartProducts = cartProducts;
        }
        public void AddProduct(IProduct product, int count)
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
        public void DeleteProduct(IProduct product, int count)
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
            StringBuilder stringBuilder = new StringBuilder("Товари:\n");
            foreach (KeyValuePair<IProduct, int> item in cartProducts)
            {
                stringBuilder.AppendLine($"{item.Key.Name} \t{item.Value} x {item.Key.Price} = {item.Value * item.Key.Price:#.00}");
            }
            stringBuilder.AppendLine($"Усього : \t{Sum()}");
            return stringBuilder.ToString();
        }
    }
}

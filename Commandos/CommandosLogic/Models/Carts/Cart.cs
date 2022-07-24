using Commandos.Models.Products.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Models.Carts
{
    public class Cart
    {
        string id;
        Dictionary<IProduct, int> cartProducts;
        public string Id { get => id; }
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
            if (count <= 0) return;
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
            if (count <= 0) return;
            if (!CartProducts.ContainsKey(product)) return;
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
            foreach (var prod in CartProducts)
            {
                sum += prod.Key.Price + prod.Value;
            }
            return sum;
        }
    }
}

using Commandos.Models.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Models.Carts
{
    public class CartsRepository
    {
        List<Cart> carts;
        private static CartsRepository instance;
        private CartsRepository()
        {
            carts = new();
        }
        public static CartsRepository GetInstance()
        {
            if (instance == null)
                instance = new CartsRepository();
            return instance;
        }
        public Cart GetCart(string id)
        {
            Cart cart = null;
            if (!string.IsNullOrWhiteSpace(id))
            {
                cart = carts.FirstOrDefault(c => c.Id == id);
            }
            if (cart == null)
            {
                cart = new Cart(id);
                carts.Add(cart);
            }
            return cart;
        }
        public void AddCart(Cart cart)
        {
            if (string.IsNullOrWhiteSpace(cart.Id)) return;
            if (carts.Any(c => c.Id == cart.Id))
            {
                carts[carts.IndexOf(carts.Find(c => c.Id == cart.Id))] = cart;
            }
            else
            {
                carts.Add(cart);
            }
        }
        public void AddCarts(List<Cart> carts)
        {
            this.carts = carts;
        }
        public void DeleteCart(Cart cart)
        {
            if (string.IsNullOrWhiteSpace(cart.Id)) return;
            if (carts.Any(c => c.Id == cart.Id))
            {
                carts.Remove(carts.Find(c => c.Id == cart.Id));
            }
        }
    }
}

using Commandos.Models.Products.General;
using Commandos.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Models.Carts
{
    public class Buy
    {
        public Check BuyCart(Cart cart)
        {
            ProductStorage<IProduct> storage = ProductStorage<IProduct>.GetInstance();
            foreach(var product in cart.CartProducts)
            {
                int resCount=storage.Buy(product.Key, product.Value);
                cart.DeleteProduct(product.Key,product.Value-resCount);
            }
            return new Check(cart); 
        }
    }
}

using Commandos.Models.Products.General;
using Commandos.Storage;

namespace Commandos.Models.Carts
{
    public class Buy
    {
        public Check BuyCart(Cart cart)
        {
            ProductStorage<IProduct> storage = ProductStorage<IProduct>.GetInstance();
            foreach (KeyValuePair<IProduct, int> product in cart.CartProducts)
            {
                int resCount = storage.Buy(product.Key, product.Value);
                cart.DeleteProduct(product.Key, product.Value - resCount);
            }
            return new Check(cart);
        }
    }
}

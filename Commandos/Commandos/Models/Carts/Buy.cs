using Commandos.Models.Products.General;
using Commandos.Storage;

namespace Commandos.Models.Carts
{
    public class Buy
    {
        private ICheckCreator checkCreator;
        public Buy( ICheckCreator creator)
        {
            checkCreator = creator;
        }
        public ICheck BuyCart(ICart cart)
        {
            ProductStorage<IProduct> storage = ProductStorage<IProduct>.GetInstance();
            foreach (KeyValuePair<IProduct, int> product in cart.CartProducts)
            {
                int resCount = storage.Buy(product.Key, product.Value);
                cart.DeleteProduct(product.Key, product.Value - resCount);
            }
            //TO DO add Payment
            return checkCreator.CreateCheck(cart);
        }
    }
}

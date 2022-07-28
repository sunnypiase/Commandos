using Commandos.Models.Pay;
using Commandos.Models.Products.General;
using Commandos.Storage;

namespace Commandos.Models.Carts
{
    public class Buy : IBuy
    {
        #region Props
        private ICheckCreator checkCreator;
        private ICheck check;
        private IPay payment;
        #endregion
        #region Ctors
        public Buy(ICheckCreator creator, IPay payment)
        {
            checkCreator = creator;
            this.payment = payment;
        }
        #endregion
        #region Methods
        public ICheck GetCheck()
        {
            return check;
        }
        public bool IsBuyAvailable(ICart cart)
        {
            ProductStorage<IProduct> storage = ProductStorage<IProduct>.GetInstance();
            foreach (KeyValuePair<IProduct, int> product in cart.CartProducts)
            {
                if (!storage.Contains(product.Key)) return false;
                if (storage.GetAmountByProduct(product.Key) < product.Value) return false;
            }
            return true;
        }
        public bool TryBuy(ICart cart)
        {       //Remove Products from storage
            ProductStorage<IProduct> storage = ProductStorage<IProduct>.GetInstance();
            foreach (KeyValuePair<IProduct, int> product in cart.CartProducts)
            {
                int resCount = storage.Buy(product.Key, product.Value);
                cart.DeleteProduct(product.Key, product.Value - resCount);
            }
            if (!payment.TryPay(cart.Sum(), out string mess))
            {   //Returt Products to storage
                foreach (KeyValuePair<IProduct, int> product in cart.CartProducts)
                {
                    storage.Add(product.Key, product.Value);
                }
                check = checkCreator.CreateCheckFail(mess);
                return false;
            }
            check = checkCreator.CreateCheck(cart);
            return true;
        }
        #endregion
    }
}

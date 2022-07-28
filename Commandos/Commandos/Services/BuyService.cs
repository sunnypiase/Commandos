using Commandos.Models.Carts;
using Commandos.Models.Pay;
using Commandos.Models.Users;

namespace Commandos.Services
{
    public class BuyService
    {
        public event Action<string> OnInfo;
        public event Func<string, object> OnGetInfo;

        public ICheck Buy()
        {
            Buy buy = new Buy(new CheckCreator(), new PayTest());
            bool result = buy.TryBuy(CartsRepository.GetInstance().GetCart((UserAccount.GetInstance().User)));
            OnInfo("Successfullly buyed!");
            OnInfo("Your check:");
            if (!result)
            {
                CartsRepository.GetInstance().GetCart(UserAccount.GetInstance().User).ClearCart();
            }
            return buy.GetCheck();
        }

    }
}

using Commandos.Models.Carts;
using Commandos.Models.Users;

namespace Commandos.Services
{
    public class BuyService
    {
        public event Action<string> OnInfo;
        public event Func<string, object> OnGetInfo;

        public Check Buy()
        {
            Check check = new Buy().BuyCart(CartsRepository.GetInstance().GetCart((UserAccount.GetInstance().User)));
            OnInfo("Successfullly buyed!");
            OnInfo("Your check:");
            CartsRepository.GetInstance().GetCart(UserAccount.GetInstance().User).ClearCart();
            return check;
        }

    }
}

using Commandos.Models.Carts;
using Commandos.Models.Users;

namespace Commandos.Services
{
    public class BuyService
    {
        public event Action<string> OnInfo;
        public event Func<string, object> OnGetInfo;

        public ICheck Buy()
        {
            ICheck check = new Buy(new CheckCreator()).BuyCart(CartsRepository.GetInstance().GetCart((UserAccount.GetInstance().User)));
            OnInfo("Successfullly buyed!");
            OnInfo("Your check:");
            CartsRepository.GetInstance().GetCart(UserAccount.GetInstance().User).ClearCart();
            return check;
        }

    }
}

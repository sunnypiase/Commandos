using Commandos.Models.Carts;
using Commandos.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Services
{
    public class BuyService
    {
        public event Action<string> OnBuyInfo;

        public Check Buy()
        {
            Check check = new Buy().BuyCart(CartsRepository.GetInstance().GetCart((UserAccount.GetInstance().User)));
            OnBuyInfo("Successfullly buyed!");
            OnBuyInfo("Your check:");
            CartsRepository.GetInstance().GetCart(UserAccount.GetInstance().User).ClearCart();
            return check;
        }
    }
}

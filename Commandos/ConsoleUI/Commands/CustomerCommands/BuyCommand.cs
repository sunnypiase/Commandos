using Commandos.Models.Carts;
using Commandos.Models.Users;
using ConsoleUI.Menu.MenuTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Commands.CustomerCommands
{
    internal class BuyCommand : CommandOn<Cart>
    {
        public BuyCommand()
        {        }
        public override object Clone()
        {
            return new BuyCommand();
        }
        public override ICollection<IMenuElement>? Execute()
        {
            List<IMenuElement> elements = new();
            Buy buy = new Buy();
            Check check = buy.BuyCart(CartsRepository.GetInstance().GetCart((UserAccount.GetInstance().User)));
            elements.Add(new InfoElement("Successfullly buyed!"));
            elements.Add(new InfoElement("Your check:"));
            elements.Add(new InfoElement(check.ToString()));
            elements.Add(new SelectableElement("back to home", "0", new BackToHome()));
            CartsRepository.GetInstance().GetCart(UserAccount.GetInstance().User).ClearCart();
            return elements;
        }
    }
}

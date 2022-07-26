using Commandos.Models.Carts;
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
        private string title;
        public BuyCommand(string title)
        {
            this.title = title;
        }
        public override object Clone()
        {
            return new BuyCommand(title);
        }
        public override ICollection<IMenuElement>? Execute()
        {
            List<IMenuElement> elements = new();
            Buy buy = new Buy();
            Check check = buy.BuyCart(CartsRepository.GetInstance().GetCart(commandTarget.Id));
            elements.Add(new InfoElement("Successfullly buyed!"));
            elements.Add(new InfoElement("Your check:"));
            elements.Add(new InfoElement(check.ToString()));
            elements.Add(new SelectableElement("back to home", "0", new BackToHome()));
            return elements;
        }
    }
}

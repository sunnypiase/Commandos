using Commandos.Models.Carts;
using Commandos.Models.Users;
using Commandos.Services;
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
        { }
        public override object Clone()
        {
            return new BuyCommand();
        }
        public override ICollection<IMenuElement>? Execute()
        {
            List<IMenuElement> elements = new();

            var service = new BuyService();
            service.OnInfo += (msg) => drawer.Write(msg);

            elements.Add(new InfoElement(service.Buy().ToString()));

            elements.Add(new SelectableElement("back to home", "0", new BackToHome()));

            return elements;
        }
        
    }
}

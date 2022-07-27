using Commandos.Models.Carts;
using Commandos.Services;
using ConsoleUI.Menu.MenuTypes;

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

            BuyService? service = new BuyService();
            service.OnInfo += (msg) => elements.Add(new InfoElement(msg));

            elements.Add(new InfoElement(service.Buy().ToString()));

            elements.Add(new SelectableElement("back to home", "0", new BackToHome()));

            return elements;
        }

    }
}

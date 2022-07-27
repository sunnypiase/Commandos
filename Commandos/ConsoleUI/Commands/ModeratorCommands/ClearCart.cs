using Commandos.Models.Carts;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands.ModeratorCommands
{
    internal class ClearCart : CommandOn<Cart>
    {
        private string title;
        public ClearCart(string title)
        {
            this.title = title;

        }
        public override object Clone()
        {
            return new ClearCart(title);
        }

        public override ICollection<IMenuElement>? Execute()
        {
            List<IMenuElement> elements = new();
            CartsRepository.GetInstance().GetCart(commandTarget.Id).ClearCart();

            elements.Add(new InfoElement("Successfullly cleared!"));
            elements.Add(new SelectableElement("back to home", "0", new BackToHome()));

            return elements;
        }
    }
}

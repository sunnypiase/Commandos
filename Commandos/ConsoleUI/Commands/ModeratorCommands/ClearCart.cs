using Commandos.Models.Carts;
using Commandos.Models.Users;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands.ModeratorCommands
{
    internal class ClearCart : CommandOn<ICart>
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
            CartsRepository.GetInstance().GetCart(UserAccount.GetInstance().User).ClearCart();

            elements.Add(new InfoElement("Successfullly cleared!"));
            elements.Add(new SelectableElement("back to home", "0", new BackToHome()));

            return elements;
        }
    }
}

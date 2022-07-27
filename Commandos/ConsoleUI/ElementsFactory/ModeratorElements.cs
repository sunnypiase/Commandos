using Commandos.Models.Products.General;
using Commandos.Models.Users;
using Commandos.Storage;
using ConsoleUI.Commands;
using ConsoleUI.Commands.ModeratorCommands;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.CommandsFactory
{
    public class ModeratorElements : IElementsFactory
    {
        private int elmCount = default;
        public ICollection<IMenuElement> GetMenuElements()
        {
            ChangeProductPrice changePrice = new("Input value in percentice %");

            List<IMenuElement> menuElements = new()
            {

                new InfoElement($"Hello {UserAccount.GetInstance()?.User?.Name}!"),

                //new SelectableElement("Add product", $"{++elmCount}", new AddProductToStorage()),

                new SelectableElement("Change product price", $"{++elmCount}", new CommandOnIEnumerable<ProductStorage<IProduct>,(IProduct,int)>(ProductStorage<IProduct>.GetInstance(),changePrice, "Whitch product price you want to change")),
                
                new SelectableElement("Exit", $"{default(int)}", new ExitCommand())
            };
            return menuElements;
        }
    }
}

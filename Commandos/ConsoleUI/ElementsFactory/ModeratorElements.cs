using Commandos.Models.Users;
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

                new SelectableElement("Add product", "0", new AddProductToStorage()),

                new SelectableElement("Change product price", $"{++elmCount}", new ActionOnStorageElements(changePrice, "Whitch product price you want to change")),
                
                new SelectableElement("Exit", "1", new ExitCommand())
            };
            return menuElements;
        }
    }
}

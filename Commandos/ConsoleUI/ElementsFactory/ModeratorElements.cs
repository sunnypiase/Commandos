using ConsoleUI.Commands;
using ConsoleUI.Commands.ModeratorCommands;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.CommandsFactory
{
    public class ModeratorElements : IElementsFactory
    {
        public ICollection<IMenuElement> GetMenuElements()
        {
            List<IMenuElement> menuElements = new()
            {
                new InfoElement("Hello"),
                new SelectableElement("Add product", "0", new AddProductToStorage()),
                new SelectableElement("Exit", "1", new ExitCommand())
            };
            return menuElements;
        }
    }
}

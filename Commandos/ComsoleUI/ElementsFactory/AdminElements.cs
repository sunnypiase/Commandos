using ConsoleUI.Commands;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.CommandsFactory
{
    public class AdminElements : IElementsFactory
    {
        public ICollection<IMenuElement> GetMenuElements()
        {
            List<IMenuElement> menuElements = new();
            menuElements.Add(new InfoElement("Hello"));
            menuElements.Add(new SelectableElement("Add product", "0", new AddProductToStorage()));
            menuElements.Add(new SelectableElement("Exit", "1", new ExitCommand()));
            return menuElements;
        }
    }
}

using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.CommandsFactory
{
    public interface IElementsFactory
    {
        public ICollection<IMenuElement> GetMenuElements();
    }
}

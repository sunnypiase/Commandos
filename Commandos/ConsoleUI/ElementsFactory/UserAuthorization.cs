using ConsoleUI.Commands;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.CommandsFactory
{
    public class UserAuthorization : IElementsFactory
    {
        private int elemsCount = default;
        public ICollection<IMenuElement> GetMenuElements()
        {
            return new List<IMenuElement>
            {
                new InfoElement("Welcome to the mega storage!"),
                new SelectableElement("Login", "1", new AuthorizationCommand()),
                new SelectableElement("Exit", "0", new ExitCommand())
            };
        }
    }
}

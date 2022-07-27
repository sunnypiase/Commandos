using Commandos.Models.Users;
using ConsoleUI.Commands;
using ConsoleUI.Commands.AdminCommands;
using ConsoleUI.Commands.ModeratorCommands;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.CommandsFactory
{
    public class AuthorizationElements : IElementsFactory
    {
        public ICollection<IMenuElement> GetMenuElements()
        {
            return new List<IMenuElement>()
            {
                new InfoElement("Welcome to the Mega Storage!"),
                new SelectableElement("Login", "1", new AuthorizationCommand()),
                new SelectableElement("Exit", "0", new ExitCommand())
            };
        }
    }
}

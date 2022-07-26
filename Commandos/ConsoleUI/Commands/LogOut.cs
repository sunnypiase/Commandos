using ConsoleUI.CommandsFactory;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public class LogOut : ICommand
    {
        public ICollection<IMenuElement>? Execute()
        {
            return new UserAuthorization().GetMenuElements();
        }
    }
}

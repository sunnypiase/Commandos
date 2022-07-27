using Commandos.Models.Users;
using ConsoleUI.CommandsFactory;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public class LogoutCommand : ICommand
    {
        public ICollection<IMenuElement>? Execute()
        {
            UserAccount.GetInstance().User = null;
            return new AuthorizationElements().GetMenuElements();
        }
    }
}
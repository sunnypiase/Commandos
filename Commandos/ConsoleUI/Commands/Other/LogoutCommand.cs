using Commandos.Logs;
using Commandos.Logs.InterfacesAndEnums;
using Commandos.Models.Users;
using ConsoleUI.CommandsFactory;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public class LogoutCommand : ICommand
    {
        public ICollection<IMenuElement>? Execute()
        {
            LogDistributor.GetInstance().Add(new Log(LogType.System, $"User {UserAccount.GetInstance().User.Name}) has logged out"));
            UserAccount.GetInstance().User = null;
            return new AuthorizationElements().GetMenuElements();
        }
    }
}
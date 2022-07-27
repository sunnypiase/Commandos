using Commandos.Logs;
using Commandos.Logs.InterfacesAndEnums;
using Commandos.Models.Users;
using Commandos.User;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public class ExitCommand : ICommand
    {
        public ICollection<IMenuElement>? Execute()
        {
            IUser user = UserAccount.GetInstance().User;
            if (user is not null)
                LogDistributor.GetInstance().Add(new Log(LogType.System, $"User {user.Name}) performed exit"));
            return null;
        }
    }
}

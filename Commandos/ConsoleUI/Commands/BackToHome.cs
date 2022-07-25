using Commandos.Models.Users;
using ConsoleUI.Menu;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public class BackToHome : ICommand
    {
        public ICollection<IMenuElement>? Execute()
        {
            return new MenuDeterminerByRole(UserAccount.GetInstance().User).GetMenuElements();
        }
    }
}

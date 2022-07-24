using Commandos.User;
using ConsoleUI.Menu;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public class BackToHome : ICommand
    {
        public ICollection<IMenuElement>? Execute(IUser? user)
        {
            return new MenuDeterminerByRole(user).GetMenuElements();
        }
    }
}

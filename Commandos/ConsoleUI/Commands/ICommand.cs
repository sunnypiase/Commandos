using Commandos.User;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public interface ICommand
    {
        public ICollection<IMenuElement>? Execute();
    }
}

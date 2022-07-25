using Commandos.User;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public class ExitCommand : ICommand
    {
        private List<int> prod = new List<int>();
        public ICollection<IMenuElement>? Execute()
        {
            return null;
        }
    }
}

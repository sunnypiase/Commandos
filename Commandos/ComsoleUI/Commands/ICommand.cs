

using Commandos.User;
using ConsoleUI.Menu;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public interface ICommand
    {
        public ICollection<IMenuElement>? Execute(IUser? user = null);
    }

    public class ExitCommand : ICommand
    {
        private List<int> prod = new List<int>();
        public ICollection<IMenuElement>? Execute(IUser? user)
        {
            return null;
        }
    }

    public class BackToHome : ICommand
    {
        public ICollection<IMenuElement>? Execute(IUser? user)
        {
            return new MenuDeterminerByRole(user).GetMenuElements();
        }
    }

    public class AddProductToStorage : ICommand
    {
        private List<int> prod = new List<int>();
        public ICollection<IMenuElement>? Execute(IUser? user)
        {
            List<IMenuElement> elements = new();
            prod.Add(1);
            elements.Add(new InfoElement("succesful"));
            elements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return elements;
        }
    }
}

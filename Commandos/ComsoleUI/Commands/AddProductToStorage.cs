using Commandos.User;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public class AddProductToStorage : ICommand
    {
        public ICollection<IMenuElement>? Execute(IUser? user)
        {
            List<IMenuElement> elements = new();
            elements.Add(new InfoElement("succesful"));
            elements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return elements;
        }
    }
}

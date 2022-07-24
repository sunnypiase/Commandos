using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public interface ICommand
    {
        public ICollection<IMenuElement> Execute();
    }

    public class AddProductCommand : ICommand
    {
        List<int> prod = new List<int>();   
        public ICollection<IMenuElement> Execute()
        {
            throw new NotImplementedException();
        }
    }
}

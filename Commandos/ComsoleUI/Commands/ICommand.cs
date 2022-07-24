using ConsoleUI.Drawers;
using ConsoleUI.Inputs;

namespace ConsoleUI.Commands
{
    public interface ICommand
    {
        public void Execute(IDrawer? drawer = null, IInput? input = null);
    }

    public class ExitCommand : ICommand
    {
        public void Execute(IDrawer? drawer = null, IInput? input = null)
        {
            throw new NotImplementedException();
        }
    }
}

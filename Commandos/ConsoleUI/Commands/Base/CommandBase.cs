using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.IO;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public abstract class CommandBase : ICommand
    {
        protected IInput input = IOSettings.GetInstance().Input;
        protected IDrawer drawer = IOSettings.GetInstance().Drawer;
        public abstract ICollection<IMenuElement>? Execute();
    }
}

using ConsoleUI.Drawers;
using ConsoleUI.Inputs;

namespace ConsoleUI.Menu
{
    public interface IMenuProcess
    {
        public IInput Input { get; }
        public IDrawer Drawer { get; }
        public void Start();
    }
}

using ConsoleUI.Drawers;
using ConsoleUI.Inputs;

namespace ConsoleUI.Menu
{
    public abstract class MenuDecorator : IMenuProcess
    {
        protected IMenuProcess menuProcess;
        public IInput Input { get => menuProcess.Input; }
        public IDrawer Drawer { get => menuProcess.Drawer; }

        public MenuDecorator(IMenuProcess menuProcess)
        {
            this.menuProcess = menuProcess;
        }

        public virtual void Start()
        {
            menuProcess.Start();
        }
    }
}

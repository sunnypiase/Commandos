using ConsoleUI.Drawers;
using ConsoleUI.Inputs;

namespace ConsoleUI.Menu
{
    public abstract class MenuDecorator : IMenuProcess
    {
        protected IMenuProcess menuProcess;
        public IInput Input => menuProcess.Input;
        public IDrawer Drawer => menuProcess.Drawer;

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

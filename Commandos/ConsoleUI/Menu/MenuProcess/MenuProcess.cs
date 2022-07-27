using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.IO;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Menu
{
    public class MenuProcess : IMenuProcess
    {
        private List<IMenuElement> menuElements;
        public IInput Input => IOSettings.GetInstance().Input;
        public IDrawer Drawer => IOSettings.GetInstance().Drawer;

        public MenuProcess(ICollection<IMenuElement> _menuElements)
        {
            menuElements = new(_menuElements.ToList());
        }

        public void Start()
        {
            ToLoop();
        }

        private void ToLoop()
        {
            bool end = false;
            ICollection<IMenuElement>? elements = menuElements;
            Drawer.Draw(menuElements);
            do
            {
                elements = Input.Choose(elements);

                Drawer.Draw(elements);

                if (elements == null)
                {
                    end = true;
                }
            }
            while (!end);
        }
    }
}

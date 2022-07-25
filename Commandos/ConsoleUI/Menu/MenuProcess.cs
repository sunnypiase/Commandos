using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.IO;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Menu
{
    public class MenuProcess
    {
        private List<IMenuElement> menuElements;
        private IInput input = IOSettings.GetInstance().Input;
        private IDrawer drawer = IOSettings.GetInstance().Drawer;
        public MenuProcess(ICollection<IMenuElement> _menuElements)
        {
            menuElements = new(_menuElements.ToList());
        }

        public void Start()
        {
            toLoop();
        }

        private void toLoop()
        {
            bool end = false;
            ICollection<IMenuElement>? elements = menuElements;
            drawer.Draw(menuElements);
            do
            {
                elements = input.Choose(elements);

                drawer.Draw(elements);

                if (elements == null)
                {
                    end = true;
                }
            }
            while (!end);
        }
    }
}

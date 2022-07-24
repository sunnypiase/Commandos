using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Menu
{
    public class MenuProcess
    {
        private List<IMenuElement> menuElements;
        private IDrawer drawer;
        private IInput input;

        public MenuProcess(ICollection<IMenuElement> _menuElements, IDrawer _drawer, IInput _input)
        {
            menuElements = new(_menuElements.ToList());
            drawer = _drawer;
            input = _input;
            Start();
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

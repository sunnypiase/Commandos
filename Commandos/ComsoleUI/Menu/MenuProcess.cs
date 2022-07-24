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
            menuElements = _menuElements.ToList();
            drawer = _drawer;
            input = _input;
            //Start();
        }

        public void Start()
        {
            toLoop();
        }

        private void toLoop()
        {
            bool end = false;
            do
            {
                drawer.Draw(menuElements);
                string? result = input.Choose(drawer);

                var menuElement = menuElements
                    .Where(el => el is SelectableElement)
                    .Select(el => (SelectableElement)el)
                    .Where(el => el.SignToCommand == result)
                    .LastOrDefault();

                menuElement?.Run(drawer, input);

                if (menuElement == null || result == "exit")
                    end = true;
            }
            while (!end);
        }
    }
}

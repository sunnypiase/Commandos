using Commandos.Models.Users;
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
            LoadingScene();
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

        private void LoadingScene(int latency = 150, int length = 11)
        {
            for (int i = 0; i < length; i++)
            {
                List<IMenuElement>? elements = new() {
                    new InfoElement($"[{new string('#', i)}{new string('-', length - i)}]")
                };
                Thread.Sleep(latency);
                drawer.Draw(elements);
            }
        }
    }
}

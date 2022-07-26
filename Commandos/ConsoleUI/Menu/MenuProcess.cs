using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.IO;
using ConsoleUI.Menu.MenuTypes;
using ConsoleUI.Menu.Music;

namespace ConsoleUI.Menu
{
    public class MenuProcess
    {
        private List<IMenuElement> menuElements;
        private IInput input = IOSettings.GetInstance().Input;
        private IDrawer drawer = IOSettings.GetInstance().Drawer;
        private IConsoleMusic music;
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

        public void SetMusic(IConsoleMusic _music)
        {
            if (drawer is ConsoleDrawer)
                music = _music;
        }

        #region Scene
        private void LoadingScene(int length = 10)
        {
            var stop = false;
            if (music is not null)
            {
                var tones = music.GetMusic().GetEnumerator();
                int musicLength = 22;
                for (int i = 0; i < musicLength && !stop; i++)
                {
                    tones.MoveNext();
                    Console.Beep(tones.Current.Item1, tones.Current.Item2);
                    List<IMenuElement>? elements = new() {
                        new InfoElement($"[{new string('#', i)}{new string('-', musicLength - i)}]")
                    };
                    Thread.Sleep(tones.Current.Item3 / 2);
                    drawer.Draw(elements);
                    drawer.Write("Press esc to skip");
                    stop = Console.KeyAvailable;
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    List<IMenuElement>? elements = new() {
                        new InfoElement($"[{new string('#', i)}{new string('-', length - i)}]")
                    };
                    drawer.Draw(elements);
                    drawer.Write("Press esc to skip");
                    stop = Console.KeyAvailable;
                }
            }
        }
        #endregion
    }
}

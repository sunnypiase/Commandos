using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.Menu.MenuTypes;
using ConsoleUI.Menu.Music;

namespace ConsoleUI.Menu
{
    public class DecoratedMenu : IMenuProcess
    {
        private IMenuProcess menuProcess;
        public IInput Input { get => menuProcess.Input; }
        public IDrawer Drawer { get => menuProcess.Drawer; }
        private IConsoleMusic music;

        public DecoratedMenu(IMenuProcess menuProcess)
        {
            this.menuProcess = menuProcess;
        }

        public void Start()
        {
            LoadingScene();
            menuProcess.Start();
        }

        public void SetMusic(IConsoleMusic _music)
        {
            if (Drawer is ConsoleDrawer)
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
                    Drawer.Draw(elements);
                    Drawer.Write("Press esc to skip");
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
                    Drawer.Draw(elements);
                    Drawer.Write("Press esc to skip");
                    stop = Console.KeyAvailable;
                }
            }
        }
        #endregion
    }
}

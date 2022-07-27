namespace ConsoleUI.Menu.Music
{
    public interface IConsoleMusic
    {
        public IEnumerable<(int, int, int)> GetMusic();
    }
}

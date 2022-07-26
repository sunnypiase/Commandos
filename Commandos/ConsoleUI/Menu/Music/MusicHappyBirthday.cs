namespace ConsoleUI.Menu.Music
{
    public class MusicHappyBirthday : IConsoleMusic
    {
        public IEnumerable<(int, int, int)> GetMusic()
        {
            yield return (264, 125, 250);
            yield return (297, 500, 125);
            yield return (264, 500, 125);
            yield return (352, 500, 125);
            yield return (330, 1000, 250);
            yield return (264, 125, 250);
            yield return (297, 500, 125);
            yield return (264, 500, 125);
            yield return (396, 500, 125);
            yield return (352, 1000, 250);
            yield return (264, 125, 250);
            yield return (264, 125, 125);
            yield return (242, 500, 125);
            yield return (440, 500, 125);
            yield return (352, 250, 125);
            yield return (330, 500, 125);
            yield return (297, 1000, 250);
            yield return (466, 125, 250);
            yield return (440, 500, 125);
            yield return (352, 500, 125);
            yield return (396, 500, 125);
            yield return (352, 1000, 100);
            GetMusic();
        }
    }
}

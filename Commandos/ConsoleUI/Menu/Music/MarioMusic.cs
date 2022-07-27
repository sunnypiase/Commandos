namespace ConsoleUI.Menu.Music
{
    public class MarioMusic : IConsoleMusic
    {
        public IEnumerable<(int, int, int)> GetMusic()
        {
            yield return (659, 125, 125);
            yield return (659, 125, 167);
            yield return (523, 125, 0);
            yield return (659, 125, 125);
            yield return (784, 125, 375);
            yield return (392, 125, 375);
            yield return (523, 125, 250);
            yield return (392, 125, 250);
            yield return (330, 125, 250);
            yield return (440, 125, 125);
            yield return (494, 125, 125);
            yield return (466, 125, 42);
            yield return (440, 125, 125);
            yield return (392, 125, 125);
            yield return (659, 125, 125);
            yield return (784, 125, 125);
            yield return (880, 125, 125);
            yield return (698, 125, 0);
            yield return (784, 125, 125);
            yield return (659, 125, 125);
            yield return (523, 125, 125);
            yield return (587, 125, 0);
            yield return (494, 125, 125);
            yield return (523, 125, 250);
            yield return (392, 125, 250);
            yield return (330, 125, 250);
            yield return (440, 125, 125);
            yield return (494, 125, 125);
            yield return (466, 125, 42);
            yield return (440, 125, 125);
            GetMusic();
        }
    }
}

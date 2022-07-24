using ConsoleUI.Drawers;

namespace ConsoleUI.Inputs
{
    public class ConsoleInput : IInput
    {
        public string? Choose(IDrawer? drawer = null)
        {
            return Console.ReadLine();
        }
    }
}

using ConsoleUI.Drawers;

namespace ConsoleUI.Inputs
{
    public interface IInput
    {
        public string? Choose(IDrawer? drawer = null);
    }
}

using ConsoleUI.Drawers;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Inputs
{
    public interface IInput
    {
        public ICollection<IMenuElement>? Choose(ICollection<IMenuElement>? menuElements);
        public string? Read(string description, IDrawer drawer);
    }
}

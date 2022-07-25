using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Drawers
{
    public interface IDrawer
    {
        public void Draw(ICollection<IMenuElement>? elements);
        public void Write(string data);
    }
}

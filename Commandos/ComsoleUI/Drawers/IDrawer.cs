using ConsoleUI.Inputs;
using ConsoleUI.Menu.MenuTypes;
using System;

namespace ConsoleUI.Drawers
{
    public interface IDrawer
    {
        public void Draw(ICollection<IMenuElement> elements);
    }
}

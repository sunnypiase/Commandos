using ConsoleUI.Drawers;

namespace ConsoleUI.Inputs
{
    public interface IInput
    {
        public ICollection<IMenuElement> Choose(ICollection<IMenuElement> menuElements);
    }
}

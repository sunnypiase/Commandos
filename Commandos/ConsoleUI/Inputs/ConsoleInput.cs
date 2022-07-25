using ConsoleUI.Drawers;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Inputs
{
    public class ConsoleInput : IInput
    {
        public ICollection<IMenuElement>? Choose(ICollection<IMenuElement>? menuElements)
        {
            string? result = Console.ReadLine();

            SelectableElement? element = menuElements?
                    .Where(el => el is SelectableElement)
                    .Select(el => (SelectableElement)el)
                    .Where(el => el.SignToCommand == result)
                    .LastOrDefault();
            return element?.Run();
        }
        public string? Read(string description, IDrawer drawer)
        {
            drawer.Write(description);
            string? result = Console.ReadLine();

            return result;
        }
    }
}

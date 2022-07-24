using ConsoleUI.Drawers;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Inputs
{
    public class ConsoleInput : IInput
    {
        public ICollection<IMenuElement>? Choose(ICollection<IMenuElement>? menuElements)
        {
            string? result = Console.ReadLine();
            var element = menuElements?
                    .Where(el => el is SelectableElement)
                    .Select(el => (SelectableElement)el)
                    .Where(el => el.SignToCommand == result)
                    .LastOrDefault();
            return element?.Run();
        }
    }
}

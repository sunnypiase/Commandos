using Commandos.Logs;
using Commandos.Logs.InterfacesAndEnums;
using ConsoleUI.Drawers;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Inputs
{
    public class ConsoleInput : IInput
    {
        public virtual ICollection<IMenuElement>? Choose(ICollection<IMenuElement>? menuElements)
        {
            string? result = Console.ReadLine();
            Console.Beep(800, 125);
            SelectableElement? element = menuElements?
                    .Where(el => el is SelectableElement)
                    .Select(el => (SelectableElement)el)
                    .Where(el => el.SignToCommand == result)
                    .LastOrDefault();

            LogDistributor.GetInstance().Add(new Log(LogType.System, element?.Title ?? "Null function"));

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

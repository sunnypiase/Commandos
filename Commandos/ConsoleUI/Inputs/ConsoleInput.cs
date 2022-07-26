using Commandos.Logs;
using ConsoleUI.Drawers;
using ConsoleUI.Menu.MenuTypes;
using Commandos.Logs.InterfacesAndEnums;
using ConsoleUI.IO;

namespace ConsoleUI.Inputs
{
    public class ConsoleInput : IInput
    {
        public virtual ICollection<IMenuElement>? Choose(ICollection<IMenuElement>? menuElements)
        {
            string? result = Console.ReadLine();

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

    public class ConsoleInputByArrows : ConsoleInput
    {
        public override ICollection<IMenuElement>? Choose(ICollection<IMenuElement>? menuElements)
        {
            var drawer = IOSettings.GetInstance().Drawer;
            List<IMenuElement>? tmpList = null;
            SelectableElement? temp = null;
            var count = menuElements.Where(el => el is SelectableElement).Count();
            int currentPos = 0;
            while (true)
            {
                var ch = Console.ReadKey().Key;
                if(ch == ConsoleKey.UpArrow)
                {
                    if(currentPos <= 0)
                    {
                        currentPos = count - 1;
                    }
                    else
                    {
                        currentPos--;
                    }
                }
                if (ch == ConsoleKey.DownArrow)
                {
                    if (currentPos >= count - 1)
                    {
                        currentPos = 0;
                    }
                    else
                    {
                        currentPos++;
                    }
                }
                tmpList = new(menuElements);
                if (temp != null)
                    temp.isOnCursor = false;
                temp = tmpList.Where(el => el is SelectableElement).Select(el => (SelectableElement)el).ToList()[currentPos];
                temp.isOnCursor = true;
                drawer.Draw(tmpList);
                if (ch == ConsoleKey.Enter)
                {
                    break;
                }
            }
            return temp.Run();
            
        }
    }
}

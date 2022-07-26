using ConsoleUI.Menu.MenuTypes;
using ConsoleUI.IO;

namespace ConsoleUI.Inputs
{
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
                    Console.Beep(800, 125);
                    break;
                }
            }
            return temp.Run();
            
        }
    }
}

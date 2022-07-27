using ConsoleUI.Inputs;
using ConsoleUI.IO;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Drawers
{
    public class ConsoleDrawer : IDrawer
    {
        public void Draw(ICollection<IMenuElement>? elements)
        {
            Console.Clear();
            if (elements == null)
            {
                return;
            }

            IEnumerable<IMenuElement> priorElements = elements.OrderBy(el => el.Priority);

            bool arrowsInput = IOSettings.GetInstance().Input is ConsoleInputByArrows;
            foreach (IMenuElement? item in priorElements)
            {
                Console.ForegroundColor = getColor(item.Priority);
                if (item is SelectableElement element)
                {
                    if (arrowsInput)
                    {
                        if (element.isOnCursor)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(">{1}", element.SignToCommand, element.Title);
                        }
                        else
                        {
                            Console.WriteLine(" {1}", element.SignToCommand, element.Title);
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0} > {1}", element.SignToCommand, element.Title);
                    }
                }
                else
                {
                    Console.WriteLine(item.Title);
                }
            }
        }

        public void Write(string data)
        {
            getColor(DrawPriority.First);
            Console.WriteLine(data);
        }

        private ConsoleColor getColor(DrawPriority drawPriority)
        {
            switch (drawPriority)
            {
                case DrawPriority.First:
                    return ConsoleColor.Cyan;
                case DrawPriority.Second:
                    return ConsoleColor.Yellow;
                default:
                    return ConsoleColor.Gray;
            }
        }
    }
}

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

            foreach (IMenuElement? item in priorElements)
            {
                if (item is SelectableElement element)
                {
                    Console.WriteLine("{0} > {1}", element.SignToCommand, element.Title);
                }
                else
                {
                    Console.WriteLine(item.Title);
                }
            }
        }

        public void Write(string data)
        {
            Console.WriteLine(data);
        }
    }
}

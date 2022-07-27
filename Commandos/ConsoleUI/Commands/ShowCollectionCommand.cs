using ConsoleUI.Menu.MenuTypes;
using System.Collections;

namespace ConsoleUI.Commands
{
    internal class ShowCollectionCommand : CommandBase
    {
        private readonly IEnumerable collection;
        private readonly string title;

        public ShowCollectionCommand(IEnumerable _collection, string _title = "List:")
        {
            collection = _collection;
            title = _title;
        }
        public override ICollection<IMenuElement>? Execute()
        {
            List<IMenuElement> elements = new();
            elements.Add(new InfoElement(title));

            foreach (object? item in collection)
            {
                elements.Add(new InfoElement($"{item}"));
            }

            elements.Add(new SelectableElement("back to home", "0", new BackToHome()));
            return elements;
        }
    }
}

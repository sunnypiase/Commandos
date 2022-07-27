using Commandos.Models.Products.General;
using Commandos.Storage;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands.CustomerCommands
{
    internal class SortStorageCommand : CommandBase
    {
        private readonly IComparer<(IProduct, int)> comparer;

        public SortStorageCommand(IComparer<(IProduct, int)> _comparer)
        {
            comparer = _comparer;
        }
        public override ICollection<IMenuElement>? Execute()
        { 
            ProductStorage<IProduct>.GetInstance().Sort(comparer);
            List<IMenuElement> elements = new();
            elements.Add(new InfoElement("Sorted storage: "));
            foreach ((IProduct Product, int Amount) item in ProductStorage<IProduct>.GetInstance())
            {
                elements.Add(new InfoElement($"{item}"));
            }
            elements.Add(new SelectableElement("back to home", "0", new BackToHome()));
            return elements;
        }
    }
}

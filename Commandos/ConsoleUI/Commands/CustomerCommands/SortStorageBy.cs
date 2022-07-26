using Commandos.Models.Products.General;
using Commandos.Storage;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands.CustomerCommands
{
    internal class SortStorageBy : CommandBase
    {
        private readonly IComparer<(IProduct, int)> comparer;

        public SortStorageBy(IComparer<(IProduct, int)> _comparer)
        {
            comparer = _comparer;
        }
        public override ICollection<IMenuElement>? Execute()
        {
            List<(IProduct Product, int Count)>? localStorage = ProductStorage<IProduct>.GetInstance().GetAll().ToList();
            localStorage.Sort(comparer);
            List<IMenuElement> elements = new();
            elements.Add(new InfoElement("Sorted storage: "));
            foreach ((IProduct Product, int Amount) item in localStorage)
            {
                elements.Add(new InfoElement($"{item}"));
            }
            elements.Add(new SelectableElement("back to home", "0", new BackToHome()));
            return elements;
        }
    }
}

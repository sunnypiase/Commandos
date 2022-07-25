using Commandos.Models.Products.General;
using Commandos.Storage;
using Commandos.User;
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.IO;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public class WhereStorage<G> : CommandBase
        where G : IProduct
    {
        private Predicate<((G Product, int Amount) element, string inputed)> predicate;
        private string title;

        public WhereStorage(Predicate<((G Product, int Amount) element, string inputed)> _predicate, string _title)
        {
            predicate = _predicate;
            title = _title;

        }

        public override ICollection<IMenuElement>? Execute()
        {

            string inputed = input.Read(title, drawer);
            ProductStorage<IProduct>? storage = ProductStorage<IProduct>.GetInstance();
            List<IMenuElement> elements = new();

            IEnumerable<(IProduct Product, int Amount)>? products = storage.Where(x => x.Product is G && predicate((((G)x.Product, x.Count), inputed)));

            foreach ((IProduct Product, int Amount) item in products)
            {
                elements.Add(new InfoElement($"{item}"));
            }
            elements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return elements;
        }
    }
}

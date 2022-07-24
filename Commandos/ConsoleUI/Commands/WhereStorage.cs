using Commandos.Models.Products.General;
using Commandos.Storage;
using Commandos.User;
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public class WhereStorage<G> : ICommand
        where G : IProduct
    {
        private Func<G, int, bool> predicate;
        private string title;
        private IInput input;
        IDrawer drawer;
        public WhereStorage(Func<G, int, bool> _predicate, string _title, IInput _input, IDrawer _drawer)
        {
            predicate = _predicate;
            title = _title;
            drawer = _drawer;
            input = _input;
        }

        public ICollection<IMenuElement>? Execute(IUser? user = null)
        {
            int num = int.Parse(input.Read(title, drawer));
            var storage = ProductStorage<IProduct>.Instance;
            List<IMenuElement> elements = new();
            var products = storage.Where(x => x is G && predicate((G)x, num));
            foreach (var item in products)
            {
                elements.Add(new InfoElement($"{item}"));
            }
            elements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return elements;
        }
    }
}

using Commandos.Models.Products.General;
using ConsoleUI.Commands;
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.CommandsFactory
{
    internal class CustomerElements : IElementsFactory
    {
        public ICollection<IMenuElement> GetMenuElements()
        {
            List<IMenuElement> menuElements = new();
            menuElements.Add(new InfoElement("Hello user"));
            menuElements.Add(new SelectableElement("Add product", "0", new AddProductToStorage()));
            menuElements.Add(new SelectableElement("Reveal products", "1", new RevealStorage()));
            menuElements.Add(new SelectableElement("Filter product by category price", "2",
                new WhereStorage<IProduct>((((IProduct product,int amount) item, string input) data) => data.item.product.Price >= int.Parse(data.input), 
                "Enter price", new ConsoleInput(), new ConsoleDrawer())));
            menuElements.Add(new SelectableElement("Exit", "3", new ExitCommand()));

            return menuElements;
        }
    }
}

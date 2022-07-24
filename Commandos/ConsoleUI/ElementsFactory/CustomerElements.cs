using Commandos.Models.Products.General;
using ConsoleUI.Commands;
using ConsoleUI.Commands.ModeratorCommands;
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.CommandsFactory
{
    internal class CustomerElements : IElementsFactory
    {
        public ICollection<IMenuElement> GetMenuElements()
        {
            return new List<IMenuElement>()
            {
                new InfoElement("Hello user"),
                new SelectableElement("Add product", "0", new AddProductToStorage()),
                new SelectableElement("Reveal products", "1", new ActionOnStorageElements<DeleteFromStorage>("Delete some product from storage")),
                new SelectableElement("Filter product by category price", "2",
                    new WhereStorage<IProduct>((((IProduct product, int amount) item, string input) data) => data.item.product.Price >= int.Parse(data.input),
                        "Enter price", new ConsoleInput(), new ConsoleDrawer())),
                new SelectableElement("Exit", "3", new ExitCommand())
            };
        }
    }
}

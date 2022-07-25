using Commandos.Models.Products.General;
using ConsoleUI.Commands;
using ConsoleUI.Commands.CustomerCommands;
using ConsoleUI.Commands.ModeratorCommands;
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.CommandsFactory
{
    internal class CustomerElements : IElementsFactory
    {
        private int elmCount = default;
        public ICollection<IMenuElement> GetMenuElements()
        {
            DeleteFromStorage deleteFromStorage = new();
            AddToCartCommand addToCart = new("Input product amount");
            return new List<IMenuElement>()
            {
                new InfoElement("Hello user"),

                new SelectableElement("Add product", $"{++elmCount}", new AddProductToStorage()),

                new SelectableElement("Reveal products", $"{++elmCount}", new ActionOnStorageElements(deleteFromStorage,"Delete some product from storage")),

                new SelectableElement("Filter product by category price", $"{++elmCount}",
                    new WhereStorage<IProduct>((((IProduct product, int amount) item, string input) data) => data.item.product.Price >= int.Parse(data.input),
                        "Enter price")),

                new SelectableElement("Add to cart", $"{++elmCount}",new ActionOnStorageElements(addToCart,"Add some product to cart")),

                new SelectableElement("Exit", $"{default(int)}", new ExitCommand())

            };
        }
    }
}

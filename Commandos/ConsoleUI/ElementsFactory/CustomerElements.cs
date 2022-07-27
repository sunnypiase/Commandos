using Commandos.Models.Carts;
using Commandos.Models.Products.General;
using Commandos.Models.Users;
using Commandos.Storage;
using ConsoleUI.Commands;
using ConsoleUI.Commands.CustomerCommands;
using ConsoleUI.Commands.ModeratorCommands;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.CommandsFactory
{
    internal class CustomerElements : IElementsFactory
    {

        private int elmCount = default;
        public ICollection<IMenuElement> GetMenuElements()
        {
            SortStorageCommand sortStorageByPrice = new SortStorageCommand(Comparer<(IProduct, int)>.Create(new Comparison<(IProduct, int)>((x, y) => x.Item1.CompareTo(y.Item1))));
            AddToCartCommand addToCart = new("Input product amount");

            return new List<IMenuElement>()
            {
                new InfoElement($"Hello {UserAccount.GetInstance()?.User?.Name}!"),

                new SelectableElement("Show products", $"{++elmCount}", new ShowCollectionCommand(ProductStorage<IProduct>.GetInstance())),

                new SelectableElement("Filter product by price", $"{++elmCount}",
                    new WhereStorage<IProduct>((((IProduct product, int amount) item, string input) data) => data.item.product.Price >= int.Parse(data.input),
                        "Enter price")),

                new SelectableElement("Sort by price +", $"{++elmCount}",
                    new SortStorageCommand(Comparer<(IProduct, int)>.Create(new Comparison<(IProduct, int)>((x, y) => x.Item1.CompareTo(y.Item1))))),

                new SelectableElement("Sort by price -", $"{++elmCount}",
                    new SortStorageCommand(Comparer<(IProduct, int)>.Create(new Comparison<(IProduct, int)>((x, y) => y.Item1.CompareTo(x.Item1))))),

                new SelectableElement("Add to cart", $"{++elmCount}",new CommandOnIEnumerable<ProductStorage<IProduct>,(IProduct,int)>(ProductStorage<IProduct>.GetInstance(),addToCart,"Add some product to cart")),

                new SelectableElement("Buy", $"{++elmCount}", new BuyCommand() ),

                new SelectableElement("Change your password", $"{++elmCount}", new ChangePasswordCommand()),

                new SelectableElement("Log out", $"{++elmCount}", new LogoutCommand()),

                new SelectableElement("Exit", $"{default(int)}", new ExitCommand())

            };
        }
    }
}

using Commandos.Models.Carts;
using Commandos.Models.Products.General;
using Commandos.Models.Users;
using Commandos.Storage;
using ConsoleUI.Commands;
using ConsoleUI.Commands.ModeratorCommands;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.CommandsFactory
{
    public class ModeratorElements : IElementsFactory
    {
        private int elmCount = default;

        public ICollection<IMenuElement> GetMenuElements()
        {
            ChangeProductPrice changePrice = new("Input value in percentice %");
            ClearCart clearCart = new("Enter cart index");
            AddProductToStorage addProduct = new("Input correct points");
            DeleteFromStorage deleteFromStorage = new();

            List<IMenuElement> menuElements = new()
            {

                new InfoElement($"Hello {UserAccount.GetInstance()?.User?.Name}!"),

                new SelectableElement("Show users", $"{++elmCount}", new ShowCollectionCommand(UsersRepository.GetInstance())),

                new SelectableElement("Show carts", $"{++elmCount}", new ShowCollectionCommand(CartsRepository.GetInstance())),

                new SelectableElement("Add product to storage", $"{++elmCount}", new CommandOnChoiseFabric<Type>(addProduct,"Add some product to storage")),

                new SelectableElement("Delete products from storage", $"{++elmCount}", new CommandOnIEnumerable<ProductStorage<IProduct>,(IProduct,int)>(ProductStorage<IProduct>.GetInstance(),deleteFromStorage,"Delete some product from storage")),

                new SelectableElement("Change product price", $"{++elmCount}", new CommandOnIEnumerable<ProductStorage<IProduct>, (IProduct, int)>(ProductStorage<IProduct>.GetInstance(), changePrice, "Whitch product price you want to change")),

                new SelectableElement("Clear customer cart", $"{++elmCount}", new CommandOnIEnumerable<CartsRepository, ICart>(CartsRepository.GetInstance(), clearCart, "Whitch cart do you want to clear")),

                new SelectableElement("Change your password", $"{++elmCount}", new ChangePasswordCommand()),

                new SelectableElement("Log out", $"{++elmCount}", new LogoutCommand()),

                new SelectableElement("Exit", $"{default(int)}", new ExitCommand())
            };
            return menuElements;
        }
    }
}

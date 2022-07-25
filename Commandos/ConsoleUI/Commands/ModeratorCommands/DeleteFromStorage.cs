using Commandos.Models.Products.General;
using Commandos.Storage;
using Commandos.User;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands.ModeratorCommands
{
    public class DeleteFromStorage : ActionOnProductCommand
    {
        public override ICollection<IMenuElement>? Execute(IUser? user = null)
        {
            ProductStorage<IProduct>? storage = ProductStorage<IProduct>.Instance;
            storage.Remove(storage.First(x => x.Product == product));
            List<IMenuElement> elements = new()
            {
                new InfoElement("Succesful"),
                new SelectableElement("back to home", "0", new BackToHome())
            };
            return elements;
        }

    }
}

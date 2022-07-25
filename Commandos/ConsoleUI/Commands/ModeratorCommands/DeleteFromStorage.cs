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
            var storage = ProductStorage<IProduct>.Instance;
            storage.Remove(product, 1); // TODO: How we get count of products here? Maybe leave constant value like 1
                                        // or remove this product from storage.
            List<IMenuElement> elements = new()
            {
                new InfoElement("Succesful"),
                new SelectableElement("back to home", "0", new BackToHome())
            };
            return elements;
        }

    }
}

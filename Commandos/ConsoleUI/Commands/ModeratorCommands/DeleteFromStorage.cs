using Commandos.Models.Products.General;
using Commandos.Storage;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands.ModeratorCommands
{
    public class DeleteFromStorage : CommandOn<(IProduct, int)>
    {
        public DeleteFromStorage()
        { }
        public DeleteFromStorage((IProduct, int) _commandTarget) : base(_commandTarget)
        { }

        public override object Clone()
        {
            return new DeleteFromStorage(commandTarget);
        }

        public override ICollection<IMenuElement>? Execute()
        {
            ProductStorage<IProduct>? storage = ProductStorage<IProduct>.GetInstance();
            storage.Remove(commandTarget.Item1, 1); // TODO: How we get count of products here? Maybe leave constant value like 1
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

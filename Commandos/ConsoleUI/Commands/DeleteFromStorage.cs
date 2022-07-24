using Commandos.Models.Products.General;
using Commandos.Storage;
using Commandos.User;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public class DeleteFromStorage : ICommand
    {
        private int i;
        public DeleteFromStorage(int i = 0)
        {
            this.i = i;
        }

        public ICollection<IMenuElement>? Execute(IUser? user = null)
        {
            ProductStorage<IProduct>? storage = ProductStorage<IProduct>.Instance;
            storage.RemoveAt(i);
            List<IMenuElement> elements = new()
            {
                new InfoElement("Succesful"),
                new SelectableElement("back to home", "0", new BackToHome())
            };
            return elements;
        }
    }
}

using Commandos.Models.Products.General;
using Commandos.Storage;
using Commandos.User;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public class RevealStorage : ICommand
    {
        public ICollection<IMenuElement>? Execute(IUser? user = null)
        {
            ProductStorage<IProduct>? storage = ProductStorage<IProduct>.Instance;

            List<IMenuElement> elements = new();

            elements.Add(new InfoElement("Delete some product from storage"));
            int i = 0;
            foreach ((IProduct Product, int Amount) item in storage)
            {
                elements.Add(new SelectableElement($"{item}", $"{i}", new DeleteFromStorage(i)));
                i++;
            }
            elements.Add(new SelectableElement("back to home", "0", new BackToHome()));
            return elements;
        }
    }
}

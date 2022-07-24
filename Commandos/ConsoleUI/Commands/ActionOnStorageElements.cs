using Commandos.Models.Products.General;
using Commandos.Storage;
using Commandos.User;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public class ActionOnStorageElements<T> : ICommand
        where T : ActionOnProductCommand, new()
    {
        private string title;
        public ActionOnStorageElements(string _title = "Select product")
        {
            title = _title;
        }
        public ICollection<IMenuElement>? Execute(IUser? user = null)
        {
            ProductStorage<IProduct>? storage = ProductStorage<IProduct>.Instance;

            List<IMenuElement> elements = new();

            elements.Add(new InfoElement(title));
            int i = default;
            foreach ((IProduct Product, int Amount) item in storage)
            {
                T? actionOnProduct = new();
                actionOnProduct.SetProduct(item.Product);
                elements.Add(new SelectableElement($"{item}", $"{++i}", actionOnProduct));
            }
            elements.Add(new SelectableElement("back to home", "0", new BackToHome()));
            return elements;
        }
    }
}

using Commandos.Models.Products.General;
using Commandos.Storage;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    public class ActionOnStorageElements : ICommand

    {
        private ActionOnProductCommand actionOnProduct;
        private string title;
        public ActionOnStorageElements(ActionOnProductCommand _actionOnProduct, string _title = "Select product")
        {
            actionOnProduct = _actionOnProduct;
            title = _title;
        }
        public ICollection<IMenuElement>? Execute()
        {
            ProductStorage<IProduct>? storage = ProductStorage<IProduct>.GetInstance();

            List<IMenuElement> elements = new();

            elements.Add(new InfoElement(title));
            int i = default;
            foreach ((IProduct Product, int Amount) item in storage)
            {
                ActionOnProductCommand tmpAction = actionOnProduct.Clone() as ActionOnProductCommand;
                tmpAction.SetProduct(item.Product);
                elements.Add(new SelectableElement($"{item}", $"{++i}", tmpAction));
            }
            elements.Add(new SelectableElement("back to home", "0", new BackToHome()));
            return elements;
        }
    }
}

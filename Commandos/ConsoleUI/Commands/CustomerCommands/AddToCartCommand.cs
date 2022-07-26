using Commandos.Models.Carts;
using Commandos.Models.Products.General;
using Commandos.Models.Users;
using Commandos.Storage;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands.CustomerCommands
{
    internal class AddToCartCommand : CommandOn<(IProduct product,int amount)>//TODO DO
    {
        private string title;



        public AddToCartCommand(string title)
        {
            this.title = title;

        }

        public override object Clone()
        {
            return new AddToCartCommand(title);
        }

        public override ICollection<IMenuElement>? Execute()
        {
            List<IMenuElement> elements = new();
            string inputed = input.Read(title, drawer);
            if (IsCanAdd(int.Parse(inputed)))
            {
                elements.Add(new InfoElement($"Not enough products in storage"));
            }
            else
            {
                CartsRepository.GetInstance().GetCart(UserAccount.GetInstance().User).AddProduct(commandTarget.product, int.Parse(inputed));
                elements.Add(new InfoElement("Product added to cart"));
            }
            elements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return elements;
        }
        private bool IsCanAdd(int inputed)
        {
            return CartsRepository.GetInstance().GetCart(UserAccount.GetInstance().User).GetAmount(commandTarget.product) + inputed > ProductStorage<IProduct>.GetInstance().GetAmountByProduct(commandTarget.product);
        }
    }
}

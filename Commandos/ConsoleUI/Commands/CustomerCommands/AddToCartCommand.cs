using Commandos.Models.Carts;
using Commandos.Models.Products.General;
using Commandos.User;
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.Menu.MenuTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Commands.CustomerCommands
{
    internal class AddToCartCommand : ActionOnProductCommand//TODO DO
    {
        private string title;
        private IInput input;
        private IDrawer drawer;

        public AddToCartCommand(string title, IInput input, IDrawer drawer)
        {
            this.title = title;
            this.input = input;
            this.drawer = drawer;
        }

        public override ICollection<IMenuElement>? Execute(IUser? user = null)
        {
            string inputed = input.Read(title, drawer);
            CartsRepository.GetInstance().GetCart("id").AddProduct(product,int.Parse(inputed));//TODO change id to Giud of userAccount
            List<IMenuElement> elements = new();
            elements.Add(new InfoElement("Product added to cart"));
            elements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return elements;
        }
    }
}

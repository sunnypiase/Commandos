using Commandos.Models.Carts;
using Commandos.Models.Products.General;
using Commandos.Models.Users;
using Commandos.User;
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.IO;
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
            IInput input = IOSettings.GetInstance().Input;
            IDrawer drawer = IOSettings.GetInstance().Drawer;

            string inputed = input.Read(title, drawer);
            CartsRepository.GetInstance().GetCart(UserAccount.GetInstance().User).AddProduct(product,int.Parse(inputed));
            List<IMenuElement> elements = new();
            elements.Add(new InfoElement("Product added to cart"));
            elements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return elements;
        }
    }
}

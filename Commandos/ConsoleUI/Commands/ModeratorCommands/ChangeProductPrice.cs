using Commandos.Models.Products.General;
using Commandos.Storage;
using ConsoleUI.Menu.MenuTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Commands.ModeratorCommands
{
    internal class ChangeProductPrice : ActionOnProductCommand
    {
        private string title;
        public ChangeProductPrice(string title)
        {
            this.title = title;

        }
        public override object Clone()
        {
            return new ChangeProductPrice(title);
        }

        public override ICollection<IMenuElement>? Execute()
        {
            List<IMenuElement> elements = new();
            string inputed = input.Read(title, drawer);
            if (!IsCanChangePrice(int.Parse(inputed)))
            {
                elements.Add(new InfoElement($"Wrond percentice!"));
            }
            else
            {
                int productIndex = ProductStorage<IProduct>.GetInstance().IndexOf(product);
                ProductStorage<IProduct>.GetInstance()[productIndex].Product.ChangePrice(int.Parse(inputed));
                elements.Add(new InfoElement("Product price changed!"));
            }
            elements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return elements;
        }
        private bool IsCanChangePrice(int percent)
        {
            return percent > -100 && percent <= 100;
        }
    }
}

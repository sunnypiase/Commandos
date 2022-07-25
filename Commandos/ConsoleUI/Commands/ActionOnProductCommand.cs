using Commandos.Models.Products.General;
using Commandos.User;
using ConsoleUI.Menu.MenuTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Commands
{
    public abstract class ActionOnProductCommand : CommandBase, ICloneable
    {
        protected IProduct product;

        public abstract object Clone();
        public virtual void  SetProduct(IProduct _product)
        {
            product = _product;
        }
    }
}

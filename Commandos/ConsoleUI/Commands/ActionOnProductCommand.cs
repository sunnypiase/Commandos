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
    public abstract class ActionOnProductCommand : ICommand, ICloneable
    {
        protected IProduct product;

        public abstract object Clone();
        public abstract ICollection<IMenuElement>? Execute(IUser? user = null);
        public virtual void  SetProduct(IProduct _product)
        {
            product = _product;
        }
    }
}

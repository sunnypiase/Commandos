using Commandos.Models.Products.General;

namespace ConsoleUI.Commands
{
    public abstract class ActionOnProductCommand : CommandBase, ICloneable
    {
        protected IProduct product;

        public abstract object Clone();
        public virtual void SetProduct(IProduct _product)
        {
            product = _product;
        }
    }
}

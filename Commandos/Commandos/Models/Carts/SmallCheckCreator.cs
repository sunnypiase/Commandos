using Commandos.Models.Products.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Models.Carts
{
    internal class SmallCheckCreator : ICheckCreator
    {
        public ICheck CreateCheck(ICart cart)
        {
            StringBuilder stringBuilder = new StringBuilder("Products:\n");
            foreach (KeyValuePair<IProduct, int> item in cart.CartProducts)
            {
                stringBuilder.AppendLine($"{item.Key.Name} \t{item.Value} {item.Value * item.Key.Price:#.00}");
            }
            stringBuilder.AppendLine($"Усього : \t{cart.Sum()}");
            stringBuilder.AppendLine("ДЯКУЄМО ЗА ПОКУПКУ!");
            return new Check(Guid.NewGuid(), cart.Sum(), stringBuilder.ToString());
        }
    }
}

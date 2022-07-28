using Commandos.Models.Carts;
using Commandos.Models.Products.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Models.Pay
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
            return new Check(cart.Sum(), stringBuilder.ToString());
        }

        public ICheck CreateCheckFail(string message)
        {
            string res = $"Операцiю вiдхилено\n{message}";
            return new CheckFail(res);
        }
    }
}

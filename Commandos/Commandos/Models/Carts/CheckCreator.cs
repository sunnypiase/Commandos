using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Models.Carts
{
    public class CheckCreator : ICheckCreator
    {
        public ICheck CreateCheck(ICart cart)
        {
            return new Check(cart);
        }
    }
}

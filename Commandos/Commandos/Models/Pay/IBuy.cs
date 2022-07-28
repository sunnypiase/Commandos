using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Models.Carts
{
    internal interface IBuy
    {
        public bool TryBuy(ICart cart);
        public bool IsBuyAvailable(ICart cart);
        public ICheck GetCheck();
    }
}

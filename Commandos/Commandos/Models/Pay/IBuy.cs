using Commandos.Models.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Models.Pay
{
    internal interface IBuy
    {
        public bool TryBuy(ICart cart);
        public bool IsBuyAvailable(ICart cart);
        public ICheck GetCheck();
    }
}

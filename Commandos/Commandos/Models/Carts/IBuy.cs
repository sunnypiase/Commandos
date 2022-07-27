using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Models.Carts
{
    internal interface IBuy
    {
        public bool TryBuy(Cart cart);
        public bool IsBuyAvailable(Cart cart);
        public Check CreateCheck(Cart cart);
    }
}

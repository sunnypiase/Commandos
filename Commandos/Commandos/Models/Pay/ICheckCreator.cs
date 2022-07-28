using Commandos.Models.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Models.Pay
{
    public interface ICheckCreator
    {
        ICheck CreateCheck(ICart cart);
        ICheck CreateCheckFail(string message);
    }
}

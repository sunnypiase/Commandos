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
        public ICheck CreateCheckFail(string message)
        {
            string mes = $"Операцiю вiдхилено. { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} \n{message}";
           return new CheckFail(mes);
        }
    }
}

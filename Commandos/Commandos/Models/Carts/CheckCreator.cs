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
        public ICheck CreateCheckFail(Guid id, string message)
        {
            string mes = $"ЧЕК N {id} вiд { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} Операцiю вiдхилено\n{message}";
           return new CheckFail(id, mes);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Models.Pay
{
    public class PayTest : IPay
    {
        public bool TryPay(double sum, out string message)
        {
            message = "Successfuly payed";
            return true;
        }
    }
}

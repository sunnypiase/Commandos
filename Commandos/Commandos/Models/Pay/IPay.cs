using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Models.Pay
{
    public interface IPay
    {
        bool TryPay(double sum, out string message);
    }
}

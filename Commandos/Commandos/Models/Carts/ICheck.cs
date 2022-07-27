using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Models.Carts
{
    public interface ICheck
    {
        public string CheckString { get; }
        public double Sum { get; }
        public Guid Id { get; }
        public DateTime DateTime { get; }
    }
}

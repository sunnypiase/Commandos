using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Models.Carts
{
    internal class CheckFail : ICheck
    {
        #region Props
        private string check;
        private double sum;
        private Guid id;
        private DateTime creatingTime;
        public string CheckString { get => check; private set => check = value; }
        public double Sum
        {
            get => sum;
            private set
            {
                if (value >= 0)
                {
                    sum = value;
                }
            }
        }
        public Guid Id { get => id; private set => id = value; }
        public DateTime CreatingTime { get => creatingTime; private set => creatingTime = value; }
        #endregion
        #region Ctors
        private CheckFail()
        {
            Id = Guid.NewGuid();
            CreatingTime = DateTime.Now;
            Sum = 0;
        }
        public CheckFail(string message):this()
        {
            CheckString = message;
        }
        #endregion
        #region Ovverrides
        public override string ToString()
        {
            return CheckString;
        }
        #endregion
    }
}

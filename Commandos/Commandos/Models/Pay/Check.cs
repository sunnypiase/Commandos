using Commandos.Models.Carts;

namespace Commandos.Models.Pay
{
    public class Check : ICheck
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
        private Check()
        {
            CreatingTime = DateTime.Now;
            Id = Guid.NewGuid();
        }
        public Check(ICart cart):this()
        {
            if (cart == null)
            {
                return;
            }

            Sum = cart.Sum();
            check = $"\tЧЕК N {Id} вiд { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} \n{cart}\n\tДЯКУЄМО ЗА ПОКУПКУ!\n";
        }
        public Check(double sum, string checkStr):this()
        {
            Sum = sum;
            CheckString = checkStr;
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

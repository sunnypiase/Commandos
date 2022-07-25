namespace Commandos.Models.Carts
{
    public class Check
    {
        #region Props
        private string check;
        private double sum;
        private Guid id;
        private DateTime dateTime;
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
        public DateTime DateTime { get => dateTime; private set => dateTime = value; }
        #endregion
        #region Ctors
        public Check(Cart cart)
        {
            if (cart == null)
            {
                return;
            }

            Sum = cart.Sum();
            DateTime = DateTime.Now;
            Id = Guid.NewGuid();
            check = $"\tЧЕК N {Id} вiд {DateTime.ToShortDateString()} {DateTime.ToShortTimeString()} \n{cart}\n\tДЯКУЄМО ЗА ПОКУПКУ!\n";
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

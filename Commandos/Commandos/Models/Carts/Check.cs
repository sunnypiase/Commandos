namespace Commandos.Models.Carts
{
    public class Check
    {
        private string check;
        private double sum;
        private string id;//TODO Change id to Guid
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
        public string Id { get => id; private set => id = value; }
        public DateTime DateTime { get => dateTime; private set => dateTime = value; }
        public Check(Cart cart)
        {
            if (cart == null)
            {
                return;
            }

            Sum = cart.Sum();
            DateTime = DateTime.Now;
            Id = Guid.NewGuid().ToString();
            check = $"\tЧЕК N {Id} вiд {DateTime.ToShortDateString()} {DateTime.ToShortTimeString()} \n{cart}\n\tДЯКУЄМО ЗА ПОКУПКУ!\n";
        }
    }
}

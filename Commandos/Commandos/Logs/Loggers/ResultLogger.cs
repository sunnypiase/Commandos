namespace Commandos.Logs.Loggers
{
    public class ResultLogger : LoggerBase
    {
        #region Fields
        private static ResultLogger _instance;
        #endregion
        #region Constructor
        private ResultLogger(string path) : base(path)
        {
        }
        #endregion
        #region Methods
        public static ResultLogger GetInstance(string path = null)
        {
            if (_instance == null)
            {
                _instance = new ResultLogger(path);
            }
            return _instance;
        }
        #endregion
    }
}

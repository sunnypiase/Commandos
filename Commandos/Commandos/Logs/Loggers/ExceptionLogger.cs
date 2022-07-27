namespace Commandos.Logs.Loggers
{
    public class ExceptionLogger : LoggerBase
    {
        #region Fields
        private static ExceptionLogger _instance;
        #endregion
        #region Constructor
        private ExceptionLogger(string path) : base(path)
        {

        }
        #endregion
        #region Methods
        public static ExceptionLogger GetInstance(string path = null)
        {
            if (_instance == null)
            {
                _instance = new ExceptionLogger(path);
            }
            return _instance;
        }
        #endregion
    }
}

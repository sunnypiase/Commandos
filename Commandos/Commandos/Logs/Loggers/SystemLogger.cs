namespace Commandos.Logs.Loggers
{
    public class SystemLogger : LoggerBase
    {
        #region Fields
        private static SystemLogger _instance;
        #endregion
        #region Constructor
        private SystemLogger(string path) : base(path)
        {

        }
        #endregion
        #region Methods
        public static SystemLogger GetInstance(string path = null)
        {
            if (_instance == null)
            {
                _instance = new SystemLogger(path);
            }
            return _instance;
        }
        #endregion
    }
}

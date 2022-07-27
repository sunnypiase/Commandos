using Commandos.Logs.InterfacesAndEnums;
using Commandos.Logs.Loggers;
using Commandos.Serialize;

namespace Commandos.Logs
{
    public class LogDistributor : ILogger
    {
        #region Fields
        private Dictionary<LogType, LoggerBase> _loggers;
        private static LogDistributor _instance;
        #endregion
        #region Constructor
        private LogDistributor()
        {
            _loggers = new Dictionary<LogType, LoggerBase>();
        }
        #endregion
        #region Methods
        public static LogDistributor GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LogDistributor();
            }
            return _instance;
        }
        public void Add(Log log)
        {
            if (!_loggers.ContainsKey(log.Title))
            {
                LoggerBase logger = null;
                switch (log.Title)
                {
                    case LogType.Result:
                        logger = ResultLogger.GetInstance(Configuration.GetInstance().AppConfiguration["ResultLog"]);
                        break;
                    case LogType.Exception:
                        logger = ExceptionLogger.GetInstance(Configuration.GetInstance().AppConfiguration["ExceptionLog"]);
                        break;
                    case LogType.System:
                        logger = SystemLogger.GetInstance(Configuration.GetInstance().AppConfiguration["SystemLog"]);
                        break;
                    default:
                        throw new ArgumentException();
                }
                _loggers.Add(log.Title, logger);
            }

            _loggers[log.Title].Add(log);
        }
        public void SaveAndClear()
        {
            Save();
            Clear();
        }
        public void Save()
        {
            foreach (KeyValuePair<LogType, LoggerBase> item in _loggers)
            {
                item.Value.Save();
            }
        }
        public void Clear()
        {
            foreach (KeyValuePair<LogType, LoggerBase> item in _loggers)
            {
                item.Value.Clear();
            }
        }
        #endregion
    }
}

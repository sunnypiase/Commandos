using Commandos.Logs.InterfacesAndEnums;
using Commandos.Logs.Loggers;
using Commandos.Serialize;
using System;

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
            if (!_loggers.ContainsKey(log.Titte))
            {
                LoggerBase logger = null;
                switch (log.Titte)
                {
                    case LogType.Result:
                        logger = new ResultLogger(Configuration.GetInstance().AppConfiguration["ResultLog"]); //TODO set concreate path
                        break;
                    case LogType.Exception:
                        logger = new ExceptionLogger(Configuration.GetInstance().AppConfiguration["ExceptionLog"]); //TODO set concreate path
                        break;
                    case LogType.System:
                        logger = new SystemLogger(Configuration.GetInstance().AppConfiguration["SystemLog"]); //TODO set concreate path
                        break;
                    default:
                        throw new ArgumentException();
                }
                _loggers.Add(log.Titte, logger);
            }

            _loggers[log.Titte].Add(log);
        }
        public void Save()
        {
            foreach (var item in _loggers)
            {
                item.Value.Save();
            }
        }
        #endregion
    }
}

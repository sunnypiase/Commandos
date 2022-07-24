using Commandos.Logs.InterfacesAndEnums;

namespace Commandos.Logs.Loggers
{
    public abstract class LoggerBase : ILogger
    {
        #region Fields
        protected List<Log> _logs;
        protected string _path;
        #endregion
        #region Constructor
        public LoggerBase(string path)
        {
            _logs = new List<Log>();
            _path = path;
        }
        #endregion
        #region Methods
        public virtual void Add(Log log)
        {
            _logs.Add(log);
        }

        public virtual void Save()
        {
            if (!File.Exists(_path))
            {
                throw new FileNotFoundException("No such file");
            }

            using (StreamWriter writer = File.AppendText(_path))
            {
                foreach (Log log in _logs)
                {
                    writer.WriteLine(log.ToString());
                }
            }
        }
        #endregion
    }
}

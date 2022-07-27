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

        public virtual void SaveAndClear()
        {
            Save();
            Clear();
        }
        public virtual void Save()
        {

            using (StreamWriter writer = File.AppendText(_path))
            {
                foreach (Log log in _logs)
                {
                    writer.WriteLine(log.ToString());
                }
            }
        }
        public virtual void Clear()
        {
            _logs.Clear();
        }

        #endregion
    }
}

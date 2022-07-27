using Commandos.Logs.InterfacesAndEnums;

namespace Commandos.Logs
{
    public class Log
    {
        #region Fields
        public LogType Title { get; private set; }
        public string Body { get; private set; }
        #endregion
        #region Constructor
        public Log(LogType titte, string body)
        {
            Title = titte;
            Body = body;
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"<Log Type: {Title}>;" + $"<Log Body: {Body}>;";
        }
        #endregion
    }
}

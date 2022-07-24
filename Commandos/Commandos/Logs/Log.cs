using Commandos.Logs.InterfacesAndEnums;

namespace Commandos.Logs
{
    public class Log
    {
        #region Fields
        public LogType Titte { get; private set; }
        public string Body { get; private set; }
        #endregion
        #region Constructor
        public Log(LogType titte, string body)
        {
            Titte = titte;
            Body = body;
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"<Log Type: {Titte}>;" +$"<Log Body: {Body}>;";
        }
        #endregion
    }
}

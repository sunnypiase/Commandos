namespace Commandos.Logs
{
    internal class Logger : IDisposable
    {
        #region Props
        private int _exCount = 0;
        private string _path;

        private static Logger _instance;
        public static Logger Instance => _instance is null ? new Logger() : _instance;
        public int ExCount => _exCount;
        public string Path { get => _path; set => _path = value; }
        #endregion
        #region Ctors
        static Logger()
        {
            _instance = new Logger();
        }
        #endregion
        #region Methods
        public void Log(string logLine)
        {
            if (_path == null)
            {
                throw new ArgumentNullException(nameof(logLine));
            }
            if (File.Exists(_path) == false)
            {
                throw new FileNotFoundException(_path);
            }
            try
            {
                using (StreamWriter sw = new(_path, true))
                {
                    sw.WriteLine(logLine + GetLogTime());
                }
                _exCount++;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private string GetLogTime()
        {
            return $"<LogTime: {DateTime.Now:G}>;";
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}

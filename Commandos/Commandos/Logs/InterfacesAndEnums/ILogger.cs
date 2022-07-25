namespace Commandos.Logs.InterfacesAndEnums
{
    public interface ILogger
    {
        void Add(Log log);
        void Save();
    }
}

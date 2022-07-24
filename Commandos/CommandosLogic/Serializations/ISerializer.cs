namespace Commandos
{
    /// <summary>
    /// Серіалізує дані типу G у тип T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface ISerializer<T>
    {
        T Serialize<G>(in G obj) where G : class;
    }
}
namespace Commandos.Serialize
{
    internal interface IStreamSerializer<T>
    {
        T Deserialize(Stream stream);
        void Serialize(T value, Stream stream);
    }
}

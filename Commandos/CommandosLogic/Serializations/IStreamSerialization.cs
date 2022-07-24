namespace Commandos.Serialize
{
    public interface IStreamSerialization<T> where T : class
    {
        public void Serialize(T obj, Stream stream);
        public T Deserialize(Stream stream);
    }
}

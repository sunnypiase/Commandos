using System.Runtime.Serialization.Json;

namespace Commandos.Serialize
{
    public class JsonStreamSerialization<T> : IStreamSerialization<T> where T : class
    {
        public void Serialize(T obj, Stream stream)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            serializer.WriteObject(stream, obj);
        }
        public T Deserialize(Stream stream)
        {
            var deserializer = new DataContractJsonSerializer(typeof(T));
            return deserializer.ReadObject(stream) as T;
        }
    }
}

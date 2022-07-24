using System.Runtime.Serialization;

namespace Commandos.Serialize
{
    public class XmlStreamSerialization<T> : IStreamSerialization<T> where T : class
    {
        public void Serialize(T obj, Stream stream)
        {
            DataContractSerializer? serializer = new DataContractSerializer(typeof(T));
            serializer.WriteObject(stream, obj);
        }
        public T Deserialize(Stream stream)
        {
            DataContractSerializer? deserializer = new DataContractSerializer(typeof(T));
            return deserializer.ReadObject(stream) as T; ;
        }
    }
}

namespace Commandos.Serialize
{
    public class SerializationFileHandler<T> where T : class
    {
        private IStreamSerialization<T> _serializer;
        private string _serializationPath;
        public SerializationFileHandler(IStreamSerialization<T> serializer, string serializationPath)
        {
            _serializer = serializer;
            _serializationPath = serializationPath;
        }
        public void Save(T obj)
        {
            using FileStream? fileStream = new FileStream(_serializationPath, FileMode.Truncate);
            _serializer.Serialize(obj, fileStream);
        }
        public T Load()
        {
            using FileStream? fileStream = new FileStream(_serializationPath, FileMode.Open);
            return _serializer.Deserialize(fileStream);
        }
    }
}

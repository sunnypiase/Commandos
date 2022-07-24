using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Commandos.Serialize
{
    internal class XmlStreamSerializer<T> : IStreamSerializer<T>
        where T : class
    {
        public XmlWriterSettings Settings { get; set; }
        public XmlStreamSerializer()
        {
            Settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                NewLineChars = Environment.NewLine,
                NewLineHandling = NewLineHandling.Replace,
                Encoding = new UTF8Encoding(false)
            };
        }

        public T Deserialize(Stream stream)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            return deserializer.Deserialize(stream) as T;
        }

        public void Serialize(T value, Stream stream)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(XmlWriter.Create(stream, Settings), value);
        }
    }
}

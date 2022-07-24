using Commandos.Models.Products.General;
using Commandos.TxtSerialize;
using System.Collections;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Commandos.Storage
{
    [Serializable]
    public class ProductStorage<T> : IList<T>, IXmlSerializable
        where T : class, IProduct
    {

        #region Props
        private static ProductStorage<T> _instance;
        [XmlIgnore]
        public static ProductStorage<T> Instance => _instance is null ? _instance = new() : _instance;
        private List<T> _products;
        /// <summary>
        /// перевіряє чи підпадає під задані умови продукт перед його додаванням
        /// </summary>
        public event Predicate<T>? OnProductPreAddFaceControl;
        /// <summary>
        /// у випадку, коли продукт не підпадає під умови додавання викликається ця подія, повинна записувати лог у файл
        /// </summary>
        public event Action<string>? OnBadProductLogger;
        public double Pirice => _products.Select(product => product.Price).Sum();
        public double MaxPrice => _products.Select(product => product.Price).Max();
        #endregion
        #region Ctors
        private ProductStorage()
        {
            _products = new();
        }

        #endregion
        #region IList
        public T this[int index]
        {
            get => _products[index];
            set => _products[index] = (T)value.Clone();
        }

        public int Count => _products.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (OnProductPreAddFaceControl?.Invoke(item) ?? true)
            {
                _products.Add((T)item.Clone());
            }
            else
            {
                OnBadProductLogger?.Invoke(new TxtSerializer().Serialize(item) + "<Describe : Продукт не підпадає під умови додавання>;");
            }
        }

        public void Clear()
        {
            _products.Clear();
        }

        public bool Contains(T item)
        {
            return _products.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _products.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _products.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _products.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            if (OnProductPreAddFaceControl?.Invoke(item) ?? true)
            {
                _products.Insert(index, (T)item.Clone());
            }
            else
            {
                OnBadProductLogger?.Invoke(new TxtSerializer().Serialize(item) + "<Describe : Продукт не підпадає під умови додавання>;");
            }
        }

        public bool Remove(T item)
        {
            return (_products.Remove(item));
        }

        public void RemoveAt(int index)
        {
            _products.RemoveAt(index);
        }

        #endregion
        #region Methods
       
        public IEnumerable<G> GetAll<G>() where G : T
        {
            foreach (T item in _products)
            {
                if (item is G result)
                {
                    yield return result;
                }
            }
        }
        public IEnumerable<G> GetAll<G>(Predicate<G> predicate) where G : T
        {
            foreach (T item in _products)
            {
                if (item is G result && predicate(result))
                {
                    yield return result;
                }
            }
        }
        public void Sort()
        {
            _products.Sort();
        }
        public void Sort(IComparer<T> comparer)
        {
            _products.Sort(comparer);
        }

        #endregion
        #region ObjectOverrides
        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (IProduct product in _products)
            {
                sb.AppendLine(product.ToString());
            }
            return sb.ToString();
        }

        public XmlSchema? GetSchema() { return null; }
        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            while (reader.IsStartElement("IProduct"))
            {
                Type type = Type.GetType(reader.GetAttribute("AssemblyQualifiedName"));
                XmlSerializer serial = new XmlSerializer(type);

                reader.ReadStartElement("IProduct");
                this.Add((IProduct)serial.Deserialize(reader) as T);
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
        }
        public void WriteXml(XmlWriter writer)
        {
            foreach (IProduct product in this)
            {
                writer.WriteStartElement("IProduct");
                writer.WriteAttributeString
                ("AssemblyQualifiedName", product.GetType().AssemblyQualifiedName);
                XmlSerializer xmlSerializer = new XmlSerializer(product.GetType());
                xmlSerializer.Serialize(writer, product);
                writer.WriteEndElement();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



        #endregion

    }
}

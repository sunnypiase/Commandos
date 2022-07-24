using Commandos.Models.Products.General;
using Commandos.TxtSerialize;
using System.Collections;
using System.Text;
using System.Xml;
using System.Xml.Schema;
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
    public class ProductStorage<T> : IList<(T Product, int Amount)>, IXmlSerializable
        where T : class, IProduct
    {

        #region Props
        private static ProductStorage<T> _instance;
        [XmlIgnore]
        public static ProductStorage<T> Instance => _instance is null ? _instance = new() : _instance;
        private List<(T Product, int Amount)> _products;
        /// <summary>
        /// перевіряє чи підпадає під задані умови продукт перед його додаванням
        /// </summary>
        public event Predicate<T>? OnProductPreAddFaceControl;
        /// <summary>
        /// у випадку, коли продукт не підпадає під умови додавання викликається ця подія, повинна записувати лог у файл
        /// </summary>
        public event Action<string>? OnBadProductLogger;
        public double Pirice => _products.Select(product => product.Product.Price).Sum();
        public double MaxPrice => _products.Select(product => product.Product.Price).Max();
        #endregion

        #region Ctors
        private ProductStorage()
        {
            _products = new();
        }

        #endregion

        #region IList

        public (T Product, int Amount) this[int index]
        {
            get => _products[index];
            set => _products[index] = value;
        }

        public int Count => _products.Count;

        public bool IsReadOnly => false;

        public void Add((T Product, int Amount) item)
        {
            if (OnProductPreAddFaceControl?.Invoke(item.Product) ?? true)
            {
                _products.Add(item);
            }
            else
            {
                OnBadProductLogger?.Invoke(new TxtSerializer().Serialize(item.Product) + "<Describe : Продукт не підпадає під умови додавання>;");
            }
        }

        public void AddOneProduct(T item, int count = 1)
        {
            if (OnProductPreAddFaceControl?.Invoke(item) ?? true)
            {
                _products.Add((item, count));
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

        public bool Contains((T Product, int Amount) item)
        {
            return _products.Contains(item);
        }
        public bool Contains(T Product)
        {
            return _products.Select(x => x.Product).Contains(Product);
        }

        public void CopyTo((T Product, int Amount)[] array, int arrayIndex)
        {
            _products.CopyTo(array, arrayIndex);
        }

        public IEnumerator<(T Product, int Amount)> GetEnumerator()
        {
            return _products.GetEnumerator();
        }

        public int IndexOf((T Product, int Amount) item)
        {
            return _products.IndexOf(item);
        }

        public void Insert(int index, (T Product, int Amount) item)
        {
            if (OnProductPreAddFaceControl?.Invoke(item.Product) ?? true)
            {
                _products.Insert(index, item);
            }
            else
            {
                OnBadProductLogger?.Invoke(new TxtSerializer().Serialize(item.Product) + "<Describe : Продукт не підпадає під умови додавання>;");
            }
        }

        public bool Remove((T Product, int Amount) item)
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
            foreach (var item in _products)
            {
                if (item.Product is G result)
                {
                    yield return result;
                }
            }
        }
        public IEnumerable<(G Product, int Amount)> GetAll<G>(Predicate<(T Product, int Amount)> predicate) where G : T
        {
            foreach (var item in _products)
            {
                if (item.Product is G result && predicate(item) )
                {
                    yield return (result, item.Amount);
                }
            }
        }
        public void Sort()
        {
            _products.Sort();
        }
        public void Sort(IComparer<(T, int)> comparer)
        {
            _products.Sort(comparer);
        }

        #endregion

        #region ObjectOverrides
        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (var product in _products)
            {
                sb.AppendLine(product.Item1.ToString() + $"[{product.Item2} points]");
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
                this.AddOneProduct((IProduct)serial.Deserialize(reader) as T);
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
        }
        public void WriteXml(XmlWriter writer)
        {
            foreach (var product in this)
            {
                writer.WriteStartElement("IProduct");
                writer.WriteAttributeString
                ("AssemblyQualifiedName", product.Item1.GetType().AssemblyQualifiedName);
                XmlSerializer xmlSerializer = new XmlSerializer(product.Item1.GetType());
                xmlSerializer.Serialize(writer, product.Item1);
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

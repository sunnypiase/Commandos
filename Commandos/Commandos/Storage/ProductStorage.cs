using Commandos.Models.Products.CementProduct;
using Commandos.Models.Products.DairyProduct;
using Commandos.Models.Products.General;
using Commandos.Models.Products.MeatProduct;
using Commandos.TxtSerialize;
using System.Collections;
using System.Runtime.Serialization;
using System.Text;

namespace Commandos.Storage
{
    [KnownType(typeof(CementProductModel))]
    [KnownType(typeof(DairyProductModel))]
    [KnownType(typeof(MeatProductModel))]
    [CollectionDataContract]
    public class ProductStorage<T> : IEnumerable<(T Product, int Count)>
        where T : class, IProduct
    {
        private static ProductStorage<T>? _instance;
        public static ProductStorage<T> GetInstance(ProductStorage<T>? ps = null)
        {
            if (_instance == null)
            {
                _instance = ps ?? new ProductStorage<T>();
            }
            return _instance;
        }

        [DataMember(Name = "Products")]
        private readonly List<(T Product, int Count)> _products = new();
        public List<(T Product, int Count)> GetProducts() => new(_products);

        #region Events

        public event Predicate<T>? OnProductPreAddFaceControl;
        public event Action<string>? OnBadProductLogger;

        #endregion

        #region Price

        public double TotalPrice => _products.Select(x => x.Product.Price * x.Count).Sum();
        public double MaxPrice => _products.Select(x => x.Product.Price).Max();
        public double MinPrice => _products.Select(x => x.Product.Price).Min();

        #endregion

        #region List wrapper

        public (T Product, int Count) this[int index]
        {
            get => _products[index];
            set => _products[index] = value;
        }

        public int Count => _products.Count;
        public void Clear() => _products.Clear();

        public void Add(T product, int countToAdd)
        {
            if (OnProductPreAddFaceControl?.Invoke(product) ?? true)
            {
                int idx = IndexOf(product);
                if (idx >= 0)
                {
                    _products[idx] = (_products[idx].Product, _products[idx].Count + countToAdd);
                }
                else
                {
                    _products.Add((product, countToAdd));
                }
            }
            else
            {
                OnBadProductLogger?.Invoke(new TxtSerializer().Serialize(product) + "<Describe : Продукт не підпадає під умови додавання>;");
            }
        }
        public void Add((T Product, int Count) item)
        {
            Add(item.Product, item.Count);
        }
        public void Remove(T product, int countToRemove)
        {
            int idx = IndexOf(product);
            if (idx >= 0)
            {
                var (p, countInStorage) = _products[idx];

                if (countInStorage > countToRemove)
                {
                    _products[idx] = (p, countInStorage - countToRemove);
                    return;
                }
                _products.RemoveAt(idx);
            }
        }
        public void Remove((T Product, int Count) item)
        {
            Remove(item.Product, item.Count);
        }
        public bool Contains(T product)
        {
            return _products.Select(x => x.Product).Contains(product);
        }
        public int IndexOf(T product)
        {
            return _products.Select(x => x.Product).ToList().IndexOf(product);
        }
        public void RemoveAt(int index)
        {
            _products.RemoveAt(index);
        }

        #endregion

        #region Methods

        public IEnumerable<(T Product, int Count)> GetAll()
        {
            foreach ((T Product, int Count) p in _products)
            {
                yield return p;
            }
        }
        public IEnumerable<(T Product, int Count)> GetAll(Type productType)
        {
            IEnumerable<(T Product, int Count)>? productsOfType = _products
                .Where(x => x.Product.GetType() == productType)
                .Select(x => x);

            foreach ((T Product, int Count) p in productsOfType)
            {
                yield return p;
            }
        }
        public IEnumerable<(T Product, int Count)> GetAll(Predicate<T> check)
        {
            IEnumerable<(T Product, int Count)>? resProducts = _products
                .Where(x => check(x.Product))
                .Select(x => x);

            foreach ((T Product, int Count) p in resProducts)
            {
                yield return p;
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
            foreach ((T Product, int Count) p in _products)
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString();
        }

        #endregion

        #region IEnumerable

        public IEnumerator<(T, int)> GetEnumerator()
        {
            return _products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}

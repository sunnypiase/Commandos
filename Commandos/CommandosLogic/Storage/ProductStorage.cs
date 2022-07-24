﻿using Commandos.Models.Products.General;
using Commandos.TxtSerialize;
using System.Collections;
using System.Text;

namespace Commandos.Storage
{
    [Serializable]
    public class ProductStorage<T> : IEnumerable<(T Product, int Count)>
        where T : class, IProduct
    {
        [NonSerialized]
        private static readonly Lazy<ProductStorage<T>> _instance = new();
        public static ProductStorage<T> Instance => _instance.Value;

        private readonly List<(T Product, int Count)> _products = new();
        public List<(T Product, int Count)> GetProducts() => new(_products);

        #region Events

        public event Predicate<T>? OnProductPreAddFaceControl;
        public event Action<string>? OnBadProductLogger;

        #endregion

        private ProductStorage() { }

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
                bool isInStorage = false;
                for (int i = 0; i < _products.Count; i++)
                {
                    if (product.Equals(_products[i].Product))
                    {
                        _products[i] = (product, _products[i].Count + countToAdd);
                        isInStorage = true;
                        break;
                    }
                }
                if (!isInStorage)
                {
                    _products.Add((product, countToAdd));
                }
            }
            else
            {
                OnBadProductLogger?.Invoke(new TxtSerializer().Serialize(product) + "<Describe : Продукт не підпадає під умови додавання>;");
            }
        }
        public void Remove(T product, int countToRemove)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if (product.Equals(_products[i].Product))
                {
                    var (prod, countInStorage) = _products[i];

                    if (countInStorage > countToRemove)
                    {
                        _products[i] = (prod, countInStorage - countToRemove);
                    }
                    else
                    {
                        _products.RemoveAt(i);
                    }
                    return;
                }
            }
        }
        public bool Contains(T product)
        {
            foreach (var p in _products)
            {
                if (product.Equals(p.Product))
                    return true;
            }
            return false;
        }
        public int IndexOf(T product)
        {
            var itemInProducts = _products.FirstOrDefault(x => x.Product == product);
            return _products.IndexOf(itemInProducts);
        }
        public void RemoveAt(int index)
        {
            _products.RemoveAt(index);
        }

        #endregion

        #region Methods

        public IEnumerable<(T Product, int Count)> GetAll()
        {
            foreach (var p in _products)
            {
                yield return p;
            }
        }
        public IEnumerable<(T Product, int Count)> GetAll(Type productType)
        {
            var productsOfType = _products
                .Where(x => x.Product.GetType() == productType)
                .Select(x => x);

            foreach (var p in productsOfType)
            {
                yield return p;
            }
        }
        public IEnumerable<(T Product, int Count)> GetAll(Predicate<T> check)
        {
            var resProducts = _products
                .Where(x => check(x.Product))
                .Select(x => x);

            foreach (var p in resProducts)
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
            foreach (var p in _products)
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
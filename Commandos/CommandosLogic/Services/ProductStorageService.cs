using Commandos.Models.Products.General;
using Commandos.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Services
{
    public class ProductStorageService
    {
        private static readonly Lazy<ProductStorageService> _instance = new();
        public static ProductStorageService Instance => _instance.Value;

        private readonly ProductStorage<(IProduct Product, int Count)> _storage;

        protected ProductStorageService()
        {
            _storage = ProductStorage<(IProduct Product, int Count)>.Instance;
        }      

        #region Methods

        public void AddProducts(IEnumerable<(IProduct Product, int Count)> products)
        {
            foreach (var prod in products)
            {
                _storage.Add(prod);
            }
        }

        public void AddProduct(IProduct product, int count)
        {
            _storage.Add((product, count));
        }

        public IProduct? GetProduct(Guid productId)
        {
            return null;
        }

        public List<(IProduct Product, int Count)>? GetAllProducts()
        {
            return null;
        }

        public void RemoveProduct(Guid productId)
        {

        }

        #endregion
    }
}

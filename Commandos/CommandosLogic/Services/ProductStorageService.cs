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
        private static ProductStorageService _instance;

        private ProductStorage<IProduct> _storage;

        protected ProductStorageService()
        {
            _storage = ProductStorage<IProduct>.Instance;
        }

        public static ProductStorageService Instance()
        {
            if (_instance == null)
                _instance = new ProductStorageService();
            return _instance;
        }

        #region Methods

        public void AddProducts(IEnumerable<(IProduct Product, int Count)> products)
        {

        }

        public void AddProduct(IProduct product, int count)
        {

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

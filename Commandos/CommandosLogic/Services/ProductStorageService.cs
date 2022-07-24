using Commandos.Models.Products.General;
using Commandos.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Services
{
    public static class ProductStorageService
    {
        private static ProductStorage<IProduct> _storage;

        static ProductStorageService()
        {
            _storage = ProductStorage<IProduct>.Instance;
        }

        public static void AddProducts(IEnumerable<(IProduct Product, int Count)> products)
        {
            foreach (var p in products)
            {
                ProductStorage<IProduct>.Instance.Add(p.Product, p.Count);
            }
        }

        public static void AddProduct(IProduct product, int count)
        {
            ProductStorage<IProduct>.Instance.Add(product, count);
        }

        public static (IProduct Product, int Count) GetProduct(Guid productId)
        {
            return _storage.GetProducts().FirstOrDefault(x => x.Product.ID == productId);
        }

        public static List<(IProduct Product, int Count)>? GetAllProducts()
        {
            return _storage.GetProducts();
        }

        public static void RemoveProduct(Guid productId, int count)
        {
            var (product, _) = GetProduct(productId);
            _storage.Remove(product, count);
        }

    }
}

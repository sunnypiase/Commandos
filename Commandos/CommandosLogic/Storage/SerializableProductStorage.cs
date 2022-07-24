using Commandos.Models.Products.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Storage
{
    internal abstract class SerializableProductStorage<T>
        where T : class, IProduct
    {
        protected ProductStorage<T> _storage;
        public SerializableProductStorage(ProductStorage<T> storage)
        {
            _storage = storage;
        }
    }
}

using Commandos.Models.Products.General;

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

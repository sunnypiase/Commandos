using Commandos.Models.Products.General;
using Commandos.Storage;
using Commandos.Models.Users;
using Commandos.Models.Carts;

namespace Commandos.Serialize
{
    public static class DownloaderProcessor
    {
        public static SerializationFileHandler<UsersRepository> GetUserDataSerializer(IStreamSerialization<UsersRepository> serialization)
        {
            return new SerializationFileHandler<UsersRepository>(serialization, Configuration.GetInstance().AppConfiguration["UsersPath"]);
        }
        public static SerializationFileHandler<ProductStorage<IProduct>> GetStorageDataSerializer(IStreamSerialization<ProductStorage<IProduct>> serialization)
        {
            return new SerializationFileHandler<ProductStorage<IProduct>>(serialization, Configuration.GetInstance().AppConfiguration["StoragePath"]);
        }
        public static SerializationFileHandler<CartsRepository> GetCartsDataSerializer(IStreamSerialization<CartsRepository> serialization)
        {
            return new SerializationFileHandler<CartsRepository>(serialization, Configuration.GetInstance().AppConfiguration["CartsPath"]);
        }
    }
}

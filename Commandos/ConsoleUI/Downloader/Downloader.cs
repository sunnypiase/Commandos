using Commandos.Logs;
using Commandos.Models.Carts;
using Commandos.Models.Products.General;
using Commandos.Models.Users;
using Commandos.Serialize;
using Commandos.Storage;
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.IO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Downloader
{
    internal class Downloader
    {
        private IStreamSerialization<ProductStorage<IProduct>> storageSerializer;
        private IStreamSerialization<UsersRepository> usersSerializer;
        private IStreamSerialization<CartsRepository> cartsSerializer;
        private IDrawer drawer;
        private IInput input;
        private string configPath;
        public Downloader()
        {

        }
        public Downloader SetStorageSerializer(IStreamSerialization<ProductStorage<IProduct>> _storageSerializer)
        {
            storageSerializer = _storageSerializer;
            return this;
        }
        public Downloader SetUsersSerializer(IStreamSerialization<UsersRepository> _usersSerializer)
        {
            usersSerializer = _usersSerializer;
            return this;
        }
        public Downloader SetCartsSerializer(IStreamSerialization<CartsRepository> _cartsSerializer)
        {
            cartsSerializer = _cartsSerializer;
            return this;
        }
        public Downloader SetSystemDrawer(IDrawer _drawer)
        {
            drawer = _drawer;
            return this;
        }
        public Downloader SetSystemInput(IInput _input)
        {
            input = _input;
            return this;
        }
        public Downloader SetConfigPath(string _path)
        {
            configPath = _path;
            return this;
        }
        public void Initialize()
        {
            Configuration.GetInstance(new ConfigurationBuilder().AddJsonFile(configPath));

            IOSettings.GetInstance(drawer, input);

            ProductStorage<IProduct>.GetInstance(DownloaderProcessor.GetStorageDataSerializer(storageSerializer).Load());

            UsersRepository.GetInstance(DownloaderProcessor.GetUserDataSerializer(usersSerializer).Load());

            CartsRepository.GetInstance(DownloaderProcessor.GetCartsDataSerializer(cartsSerializer).Load());
        }
        public void Save()
        {

            DownloaderProcessor.GetStorageDataSerializer(storageSerializer).Save(ProductStorage<IProduct>.GetInstance());
            DownloaderProcessor.GetUserDataSerializer(usersSerializer).Save(UsersRepository.GetInstance());
            DownloaderProcessor.GetCartsDataSerializer(cartsSerializer).Save(CartsRepository.GetInstance());
            LogDistributor.GetInstance().SaveAndClear();
        }
    }
}

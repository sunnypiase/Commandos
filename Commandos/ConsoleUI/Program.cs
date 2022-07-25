using Commandos.Logs;
using Commandos.Models.Products.DairyProduct;
using Commandos.Models.Products.General;
using Commandos.Serialize;
using Commandos.Storage;
using Microsoft.Extensions.Configuration;
internal static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.InputEncoding = System.Text.Encoding.Unicode;
        try
        {
            Configuration.GetInstance(new ConfigurationBuilder().AddJsonFile(@"C:\Users\Sunny Piase\source\repos\NewRepo\Commandos\Commandos\Files\config.json"));
            LogDistributor distributor = LogDistributor.GetInstance();

            var storage = ProductStorage<IProduct>.Instance;
            storage.Add((new DairyProductModel("milk", 500, 20, DateTime.Now, null), 2));
            storage.Add((new DairyProductModel("milk1", 5, 50, DateTime.Now.AddDays(2), null), 3));
            DownloaderProcessor.GetStorageDataSerializer(new XmlStreamSerialization<ProductStorage<IProduct>>()).Save(ProductStorage<IProduct>.Instance);

            var storage2 = DownloaderProcessor
                .GetStorageDataSerializer(new XmlStreamSerialization<ProductStorage<IProduct>>())
                .Load();

            Console.WriteLine(ProductStorage<IProduct>.Instance);
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            //DownloaderProcessor.GetStorageDataSerializer(new XmlStreamSerialization<ProductStorage<IProduct>>()).Save(ProductStorage<IProduct>.Instance);
            //DownloaderProcessor.GetStorageDataSerializer(new JsonStreamSerialization<ProductStorage<IProduct>>()).Save(ProductStorage<IProduct>.Instance);

        }


        //var storage = ProductStorage<IProduct>.Instance;
        //storage.Add((new DairyProductModel("milk", 500, 20, DateTime.Now, null), 2));
        //storage.Add((new DairyProductModel("milk1", 5, 50, DateTime.Now.AddDays(2), null), 3));

        //IUser user = new User("TOLYAN", Guid.NewGuid(), Commandos.Role.Roles.Customer);
        //MenuDeterminerByRole menuDeterm = new(user);
        //MenuProcess menu = new(menuDeterm.GetMenuElements(), new ConsoleDrawer(), new ConsoleInput());
        //menu.Start();
        //distributor.Save();
    }

    //TODO public void Quit() { } // this method should close and save everything before exiting
    // for example, it should call UsersRepository.GetInstance().SaveUsersToFile();


}
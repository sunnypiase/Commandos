using Commandos.Logs;
using Commandos.Models.Carts;
using Commandos.Models.Products.DairyProduct;
using Commandos.Models.Products.General;
using Commandos.Serialize;
using Commandos.Storage;
using Commandos.User;
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.Menu;
using Microsoft.Extensions.Configuration;
internal static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.InputEncoding = System.Text.Encoding.Unicode;
        try
        {
            //Configuration.GetInstance(new ConfigurationBuilder().AddJsonFile(@"C:\Users\Sunny Piase\source\repos\NewRepo\Commandos\Commandos\Files\config.json"));
            LogDistributor distributor = LogDistributor.GetInstance();
            //DownloaderProcessor.GetStorageDataSerializer(new XmlStreamSerialization<ProductStorage<IProduct>>()).Load();
            //Console.WriteLine(ProductStorage<IProduct>.Instance);
            //CartsRepository.Instance.Add(new Cart("id"));//TEST
            ProductStorage<IProduct>? storage = ProductStorage<IProduct>.Instance;
            storage.Add((new DairyProductModel("milk", 500, 20, DateTime.Now, null), 2));
            storage.Add((new DairyProductModel("milk1", 5, 50, DateTime.Now.AddDays(2), null), 3));

            // Users can not be created this way, names and passwords should be set during authorisation.
            // Passwords are encrypted, and the users repository should be saved to disk before exit to save the login and password
            // Here should be called the menu with AuthorizationCommand and Exit items
            IUser user = new User("TOLYAN", Guid.NewGuid(), Commandos.Role.Roles.Customer, "StrangePassword");
            MenuDeterminerByRole menuDeterm = new(user);
            MenuProcess menu = new(menuDeterm.GetMenuElements(), new ConsoleDrawer(), new ConsoleInput());
            menu.Start();
            Console.WriteLine(CartsRepository.Instance);
            Console.WriteLine("-----------------------------------------");
            //Console.WriteLine(CartsRepository.Instance.GetCart("id"));
            distributor.Save();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ex.StackTrace);
            throw;
        }
        finally
        {
            //DownloaderProcessor.GetStorageDataSerializer(new XmlStreamSerialization<ProductStorage<IProduct>>()).Save(ProductStorage<IProduct>.Instance);
            //DownloaderProcessor.GetStorageDataSerializer(new JsonStreamSerialization<ProductStorage<IProduct>>()).Save(ProductStorage<IProduct>.Instance);

        }


    }

    //TODO public void Quit() { } // this method should close and save everything before exiting
    // for example, it should call UsersRepository.GetInstance().SaveUsersToFile();


}
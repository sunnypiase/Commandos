﻿using Commandos.Logs;
using Commandos.Models.Carts;
using Commandos.Models.Products.DairyProduct;
using Commandos.Models.Products.General;
using Commandos.Models.Users;
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
            Configuration.GetInstance(new ConfigurationBuilder().AddJsonFile(Path.GetFullPath(@"..\..\..\..\Commandos\Files\config.json")));
            LogDistributor distributor = LogDistributor.GetInstance();

            ProductStorage<IProduct>
                .GetInstance(DownloaderProcessor.GetStorageDataSerializer(new XmlStreamSerialization<ProductStorage<IProduct>>())
                .Load());

            UsersRepository
                .GetInstance(DownloaderProcessor.GetUserDataSerializer(new XmlStreamSerialization<UsersRepository>())
                .Load());

            CartsRepository
                .GetInstance(DownloaderProcessor.GetCartsDataSerializer(new XmlStreamSerialization<CartsRepository>())
                .Load());

            IUser user = new User("TOLYAN", Guid.NewGuid(), Commandos.Role.Roles.Customer, "asd");
            /*CartsRepository.GetInstance().Add(new Cart(user));*/
            UserAccount.GetInstance(user);
            MenuDeterminerByRole menuDeterm = new(user);
            MenuProcess menu = new(menuDeterm.GetMenuElements(), new ConsoleDrawer(), new ConsoleInput());
            menu.Start();
            Console.WriteLine(CartsRepository.GetInstance().GetCart(UserAccount.GetInstance().User));
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ex.StackTrace);
        }
        finally
        {
            //DownloaderProcessor.GetStorageDataSerializer(new XmlStreamSerialization<ProductStorage<IProduct>>()).Save(ProductStorage<IProduct>.Instance);
            //DownloaderProcessor.GetStorageDataSerializer(new JsonStreamSerialization<ProductStorage<IProduct>>()).Save(ProductStorage<IProduct>.Instance);
            //DownloaderProcessor.GetCartsDataSerializer(new XmlStreamSerialization<CartsRepository>()).Save(CartsRepository.GetInstance());
        }


        //var storage = ProductStorage<IProduct>.Instance;
        //storage.Add((new DairyProductModel("milk", 500, 20, DateTime.Now, null), 2));
        //storage.Add((new DairyProductModel("milk1", 5, 50, DateTime.Now.AddDays(2), null), 3));

        //distributor.Save();
    }

    //TODO public void Quit() { } // this method should close and save everything before exiting
    // for example, it should call UsersRepository.GetInstance().SaveUsersToFile();

Console.WriteLine(storage);

Console.ReadLine();
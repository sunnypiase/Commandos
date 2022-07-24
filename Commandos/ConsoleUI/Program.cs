using Commandos;
using Commandos.Logs;
using Commandos.Logs.InterfacesAndEnums;
using Commandos.Models.Products.MeatProduct;
using Commandos.Serialize;
using Commandos.User;
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.Menu;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
internal static class Program
{
    public static void Main(string[] args)
    {
        Configuration.GetInstance(new ConfigurationBuilder().AddJsonFile(@"C:\Users\Sunny Piase\source\repos\NewRepo\Commandos\Commandos\Files\config.json"));
        Console.WriteLine("Hello, World!");
        MeatProductModel _meatProduct = new MeatProductModel();
        LogDistributor distributor = LogDistributor.GetInstance();
        distributor.Add(new Log(LogType.Result, "Result Log"));
        distributor.Add(new Log(LogType.Exception, "Exception Log"));
        distributor.Add(new Log(LogType.System, "System Log"));
        IUser user = new User("TOLYAN", Guid.NewGuid(), Commandos.Role.Roles.Customer);
        MenuDeterminerByRole menuDeterm = new(user);
        MenuProcess menu = new(menuDeterm.GetMenuElements(), new ConsoleDrawer(), new ConsoleInput());
        menu.Start();
        distributor.Save();
    }

    //TODO public void Quit() { } // this method should close and save everything before exiting
                           // for example, it should call UsersRepository.GetInstance().SaveUsersToFile();


}
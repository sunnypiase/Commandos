using Commandos;
using Commandos.Logs;
using Commandos.Logs.InterfacesAndEnums;
using Commandos.Models.Products.DairyProduct;
using Commandos.Models.Products.General;
using Commandos.Models.Products.MeatProduct;
using Commandos.Serialize;
using Commandos.Storage;
using Commandos.User;
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.Menu;
using Microsoft.Extensions.Configuration;
internal static class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.InputEncoding = System.Text.Encoding.Unicode;

        var storage = ProductStorage<IProduct>.Instance;

        storage.Add(new DairyProductModel("milk", 500, 20, new DateTime(2002), null));
        storage.Add(new DairyProductModel("milk1", 5, 50, new DateTime(2002), null));


        IUser user = new User("TOLYAN", Guid.NewGuid(), Commandos.Role.Roles.Customer);
        MenuDeterminerByRole menuDeterm = new(user);
        MenuProcess menu = new(menuDeterm.GetMenuElements(), new ConsoleDrawer(), new ConsoleInput());
        menu.Start();

        
    }

    //TODO public void Quit() { } // this method should close and save everything before exiting
    // for example, it should call UsersRepository.GetInstance().SaveUsersToFile();


}
using Commandos.Logs;
using Commandos.Logs.InterfacesAndEnums;
using Commandos.Models.Carts;
using Commandos.Models.Products.General;
using Commandos.Models.Users;
using Commandos.Serialize;
using Commandos.Storage;
using Commandos.User;
using ConsoleUI.CommandsFactory;
using ConsoleUI.Downloader;
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.IO;
using ConsoleUI.Menu;
using ConsoleUI.Menu.Music;
using Microsoft.Extensions.Configuration;
internal static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.InputEncoding = System.Text.Encoding.Unicode;
        Downloader? loader = null;

        try
        {
            loader = new Downloader().SetStorageSerializer(new XmlStreamSerialization<ProductStorage<IProduct>>())
                                     .SetCartsSerializer(new XmlStreamSerialization<CartsRepository>())
                                     .SetUsersSerializer(new XmlStreamSerialization<UsersRepository>())
                                     .SetSystemDrawer(new ConsoleDrawer())
                                     .SetSystemInput(new ConsoleInputByArrows())
                                     .SetConfigPath(Path.GetFullPath(@"..\..\..\..\Commandos\Files\config.json"));
            loader.Initialize();

            MenuProcess menu = new(new AuthorizationElements().GetMenuElements());
            LoadingMenu decoratedMenu = new(menu);
            decoratedMenu.SetMusic(new MarioMusic());
            decoratedMenu.Start();

        }
        catch (Exception ex)
        {
            LogDistributor.GetInstance().Add(new Log(LogType.Exception, ex.Message));
            IOSettings.GetInstance().Drawer.Write(ex.Message + ex.StackTrace);
        }
        finally
        {
            loader?.Save();
        }
    }
}


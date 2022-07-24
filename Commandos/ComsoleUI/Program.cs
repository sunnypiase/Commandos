using Commandos;
using Commandos.Logs;
using Commandos.Logs.InterfacesAndEnums;
using Commandos.Models.Products.MeatProduct;
using Commandos.Serialize;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
internal static class Program
{
    public int Main(string[] args)
    {
        Configuration.GetInstance(new ConfigurationBuilder().AddJsonFile(""));
        Console.WriteLine("Hello, World!");
        MeatProductModel _meatProduct = new MeatProductModel();
        LogDistributor distributor = LogDistributor.GetInstance();
        distributor.Add(new Log(LogType.System, "System Log"));
        distributor.Add(new Log(LogType.System, "System Log"));
    }

    public void Quit() { } // this method should close and save everything before exiting
                           // for example, it should call UsersRepository.GetInstance().SaveUsersToFile();


}
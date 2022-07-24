using Commandos;
using Commandos.Logs;
using Commandos.Logs.InterfacesAndEnums;
using Commandos.Models.Products.MeatProduct;

Console.WriteLine("Hello, World!");
MeatProductModel _meatProduct = new MeatProductModel();
LogDistributor distributor = LogDistributor.GetInstance();
distributor.Add(new Log(LogType.System, "System Log"));
distributor.Add(new Log(LogType.System, "System Log"));
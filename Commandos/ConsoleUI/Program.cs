using Commandos.Logs;
using Commandos.Models.Products.DairyProduct;
using Commandos.Models.Products.General;
using Commandos.Serialize;
using Commandos.Storage;
using Microsoft.Extensions.Configuration;

//Console.OutputEncoding = 

var storage = ProductStorage<IProduct>.Instance;

storage.Add(new DairyProductModel("milk", 500, 20, DateTime.Now), 2);
storage.Add(new DairyProductModel("milk1", 5, 50, DateTime.Now.AddDays(2)), 3);

Console.WriteLine("Contains: {0}", storage.Contains(new DairyProductModel("milk", 500, 20, DateTime.Now)));

Console.WriteLine(storage);

Console.ReadLine();
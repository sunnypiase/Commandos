using Commandos.Logs;
using Commandos.Models.Products.DairyProduct;
using Commandos.Models.Products.General;
using Commandos.Serialize;
using Commandos.Storage;
using Microsoft.Extensions.Configuration;

//Console.OutputEncoding = 

var storage = ProductStorage<IProduct>.Instance;
var p1 = new DairyProductModel("milk", 500, 20, DateTime.Now);
var p2 = new DairyProductModel("milk1", 5, 50, DateTime.Now.AddDays(2));

storage.Add(p1, 2);
storage.Add(p2, 3);

Console.WriteLine("Contains: {0}", storage.Contains(new DairyProductModel("milk", 500, 20, DateTime.Now)));
Console.WriteLine(storage.IndexOf(p2));

Console.WriteLine(storage);

Console.ReadLine();
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.Menu;
using ConsoleUI.User;

Console.WriteLine("Hello, World!");
User user = new User("Alex", Guid.NewGuid(), Roles.Customer);
MenuDeterminerByRole determiner = new(user);
MenuProcess menu = new(determiner.GetMenuElements(), new ConsoleDrawer(), new ConsoleInput());

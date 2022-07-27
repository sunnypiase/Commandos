using Commandos.Models.Users;
using ConsoleUI.Commands;
using ConsoleUI.Commands.AdminCommands;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.CommandsFactory
{
    public class AdminElements : IElementsFactory
    {
        private int elemsCount = default;
        public ICollection<IMenuElement> GetMenuElements()
        {
            return new List<IMenuElement>
            {
                new InfoElement($"Hello {UserAccount.GetInstance()?.User?.Name}!"),
               // new SelectableElement("Add product", $"{++elemsCount}", new AddProductToStorage()),
                new SelectableElement("Change user role",$"{++elemsCount}",new ChangeUserRoleCommand("Enter user nickname: ", "Enter role for this user: ")),
                new SelectableElement("Delete user", $"{++elemsCount}", new RemoveUserFromRepositoryCommand("Enter user nickname: ")),
                new SelectableElement("Log out", $"{++elemsCount}", new LogoutCommand()),
                new SelectableElement("Exit", $"{default(int)}", new ExitCommand())
            };
        }
    }
}

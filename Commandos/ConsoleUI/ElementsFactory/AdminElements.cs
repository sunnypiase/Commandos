using Commandos.Models.Users;
using Commandos.Role;
using Commandos.User;
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
                new SelectableElement("Show all users", $"{++elemsCount}", new ShowCollectionCommand(UsersRepository.GetInstance())),
                new SelectableElement("Select and change user role", $"{++elemsCount}", new CommandOnIEnumerable<UsersRepository, IUser>(UsersRepository.GetInstance(),new ChangeSelectedUserRoleCommand(),"Select user")),
                new SelectableElement("Change user role by login",$"{++elemsCount}",new ChangeUserRoleCommand("Enter user nickname: ", "Enter role for this user: ")),
                new SelectableElement("Select and delete user", $"{++elemsCount}", new CommandOnIEnumerable<UsersRepository, IUser>(UsersRepository.GetInstance(),new RemoveSelectedUserFromRepositoryCommand(),"Select user")),
                new SelectableElement("Delete user by login", $"{++elemsCount}", new RemoveUserFromRepositoryCommand("Enter user nickname: ")),
                new SelectableElement("Change your password", $"{++elemsCount}", new ChangePasswordCommand()),
                new SelectableElement("Log out", $"{++elemsCount}", new LogoutCommand()),
                new SelectableElement("Exit", $"{default(int)}", new ExitCommand())
            };
        }
    }
}

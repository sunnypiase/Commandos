using Commandos.Logs;
using Commandos.Logs.InterfacesAndEnums;
using Commandos.Models.Carts;
using Commandos.Models.Users;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands.AdminCommands
{
    public class RemoveUserFromRepositoryCommand : CommandBase
    {
        private readonly string _userMessage;
        public RemoveUserFromRepositoryCommand(string userMessage)
        {
            _userMessage = userMessage;
        }

        public override ICollection<IMenuElement>? Execute()
        {
            List<IMenuElement>? menuElements = new List<IMenuElement>();
            string? chosenNickname = input.Read(_userMessage, drawer);
            UsersRepository? users = UsersRepository.GetInstance();
            Commandos.User.IUser? chosenPerson = users.GetPersonByName(chosenNickname);
            if (chosenPerson == null)
            {
                menuElements.Add(new InfoElement($"There is no user with nickname {chosenNickname}!"));
            }
            else
            {
                users.RemoveUser(chosenPerson);
                CartsRepository? carts = CartsRepository.GetInstance();
                carts.Remove(carts.GetCart(chosenPerson));
                LogDistributor.GetInstance().Add(new Log(LogType.System, $"User with nickname {chosenNickname} has been deleted"));
                menuElements.Add(new InfoElement($"Successfully deleted user with nickname {chosenNickname}"));
            }
            menuElements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return menuElements;
        }
    }
}

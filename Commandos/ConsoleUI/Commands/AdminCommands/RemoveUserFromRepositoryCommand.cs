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
            var menuElements = new List<IMenuElement>();
            var chosenNickname = input.Read(_userMessage, drawer);
            var users = UsersRepository.GetInstance();
            var chosenPerson = users.GetPersonByName(chosenNickname);
            if (chosenPerson == null)
            {
                menuElements.Add(new InfoElement($"There is no user with nickname {chosenNickname}!"));
            }
            else
            {
                users.RemoveUser(chosenPerson);
                var carts = CartsRepository.GetInstance();
                carts.Remove(carts.GetCart(chosenPerson));
                menuElements.Add(new InfoElement($"Successfully deleted user with nickname {chosenNickname}"));
            }
            menuElements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return menuElements;
        }
    }
}

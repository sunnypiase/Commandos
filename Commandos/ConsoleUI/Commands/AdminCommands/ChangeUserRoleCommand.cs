using Commandos.Models.Users;
using Commandos.Role;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands.AdminCommands
{
    public class ChangeUserRoleCommand : CommandBase
    {
        private readonly string _userMessage;
        private readonly string _roleMessage;
        public ChangeUserRoleCommand(string userMessage, string roleMessage)
        {
            _userMessage = userMessage;
            _roleMessage = roleMessage;
        }

        public override ICollection<IMenuElement>? Execute()
        {
            List<IMenuElement>? menuElements = new List<IMenuElement>();
            string? chosenNickname = input.Read(_userMessage, drawer);
            Commandos.User.IUser? chosenPerson = UsersRepository.GetInstance().GetPersonByName(chosenNickname);
            if (chosenPerson == null)
            {
                menuElements.Add(new InfoElement($"There is no user with nickname {chosenNickname}!"));
            }
            else
            {
                string? chosenRole = input.Read(_roleMessage, drawer);
                if (!Enum.TryParse(chosenRole, true, out Roles role))
                {
                    menuElements.Add(new InfoElement($"There is no role {chosenRole}!"));
                }
                else
                {
                    menuElements.Add(new InfoElement($"Role of the user with nickname {chosenNickname} has been changed to \"{chosenRole}\"!"));
                    chosenPerson.Role = role;
                }

            }
            menuElements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return menuElements;
        }
    }
}

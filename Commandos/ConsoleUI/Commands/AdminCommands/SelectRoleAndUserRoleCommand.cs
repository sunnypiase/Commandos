using Commandos.Models.Users;
using Commandos.Role;
using Commandos.User;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands.AdminCommands
{
    public class ChangeSelectedUserRoleCommand : CommandOn<IUser>
    {

        public ChangeSelectedUserRoleCommand()
    {
    }

    public override object Clone()
    {
        return new ChangeSelectedUserRoleCommand(); ;
    }


    public override ICollection<IMenuElement>? Execute()
        {
            var menuElements = new List<IMenuElement>();
             var chosenPerson = commandTarget;
            if (chosenPerson == null)
            {
                menuElements.Add(new InfoElement($"There is no selected user!"));
            }
            else
            {
                var chosenRole = input.Read("Enter role for this user: ", drawer);
                if (!Enum.TryParse(chosenRole, true, out Roles role))
                {
                    menuElements.Add(new InfoElement($"There is no role {chosenRole}!"));
                }
                else
                {
                    menuElements.Add(new InfoElement($"Role of the user with nickname {chosenPerson.Name} has been changed to \"{chosenRole}\"!"));
                    chosenPerson.Role = role;
                }

            }
            menuElements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return menuElements;
        }
    }
}

using Commandos.Models.Users;
using Commandos.Role;
using Commandos.User;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands.AdminCommands
{
    public class SelectRoleAndUserRoleCommand : CommandOn<Roles>
    {
        IUser user;
        public SelectRoleAndUserRoleCommand(IUser _user)
    {
            this.user = _user;
    }

    public override object Clone()
    {
        return new SelectRoleAndUserRoleCommand(user); ;
    }


    public override ICollection<IMenuElement>? Execute()
        {
            var menuElements = new List<IMenuElement>();
            Roles newRole = commandTarget;
            if (newRole == null)
            {
                menuElements.Add(new InfoElement($"Role is no selected!"));
            }
            else
            {
                menuElements.Add(new InfoElement($"Role of the user with nickname {user.Name} has been changed to \"{newRole}\"!"));
                user.Role = newRole;
            }

            menuElements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return menuElements;
        }
    }
}

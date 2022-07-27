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
            string tmp = "";
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
                int elmCount = 0;
                List<Roles> listRoles = Enum.GetValues<Roles>().ToList();
                var c = new CommandOnIEnumerable<IEnumerable<Roles>, Roles>(listRoles, new SelectRoleAndUserRoleCommand(chosenPerson), "Select new role for "+chosenPerson.Name+"!");
                menuElements.Add(new SelectableElement("Choose new role for "+ chosenPerson.Name, $"{++elmCount}", c));
            }
            menuElements.Add(new SelectableElement("Exit", "0", new BackToHome()));
            return menuElements;
        }
    }
}

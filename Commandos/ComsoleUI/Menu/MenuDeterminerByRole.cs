using Commandos.Role;
using Commandos.User;
using ConsoleUI.CommandsFactory;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Menu
{
    public class MenuDeterminerByRole
    {
        private IElementsFactory commands;

        public MenuDeterminerByRole(IUser? user)
        {
            switch (user?.Role)
            {
                case Roles.Customer:
                    commands = new CustomerElements();
                    break;
                case Roles.Admin:
                    commands = new AdminElements();
                    break;
                case Roles.Moderator:
                    commands = new ModeratorElements();
                    break;
                default:
                    commands = new CustomerElements();
                    break;
            }
        }

        public ICollection<IMenuElement> GetMenuElements()
        {
            return commands.GetMenuElements();
        }
    }
}

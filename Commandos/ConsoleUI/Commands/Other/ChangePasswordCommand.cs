using Commandos.Logs;
using Commandos.Logs.InterfacesAndEnums;
using Commandos.Models.Users;
using Commandos.Role;
using Commandos.Services;
using Commandos.User;
using ConsoleUI.Menu;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands
{
    internal class ChangePasswordCommand : CommandBase  // used for user's login

    {
        private AuthorizationService authorizationService;

        public ChangePasswordCommand()
        {
            authorizationService = new();
        }

        public override ICollection<IMenuElement>? Execute()
        {
            UserAccount userAccount = UserAccount.GetInstance();
            if (userAccount is null || userAccount.User is null)
            {
                return null; // no current user, this command cannot be used
            }
            var menuElements = new List<IMenuElement>();
            var newPassword = input.Read("Enter new password:", drawer);
            if (!authorizationService.CheckPasswordStrength(newPassword))
            {
                newPassword = input.Read("Password should be longer than 7 characters and contain at least one letter and one digit. Try again:", drawer);
                if (!authorizationService.CheckPasswordStrength(newPassword))
                {
                    menuElements.Add(new InfoElement("Wrong password. Change is not performed."));
                }
                else // password is OK, change the password
                {
                    authorizationService.ChangePassword(userAccount.User, newPassword);
                    LogDistributor.GetInstance().Add(new Log(LogType.System, $"User {userAccount.User.Name}) has changed his password"));
                    menuElements.Add(new InfoElement("Password has been changed."));
                }
            }
            else // password is OK, change the password
            {
                authorizationService.ChangePassword(userAccount.User, newPassword);
                LogDistributor.GetInstance().Add(new Log(LogType.System, $"User {userAccount.User.Name}) has changed his password"));
                menuElements.Add(new InfoElement("Password has been changed."));
            }
            menuElements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return menuElements;
        }
    }
}

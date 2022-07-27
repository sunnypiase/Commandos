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
    internal class AuthorizationCommand : CommandBase  // used for user's login

    {
        private AuthorizationService authorizationService;

        public AuthorizationCommand()
        {
            authorizationService = new();
        }

        private UserAccount? LoginRoutine()
        {
            // Enter login (nickname)
            string? currentLogin = input.Read("Enter nickname:", drawer);
            if (string.IsNullOrEmpty(currentLogin))
            {
                return null;
            }
            // Check if nickname exists in the user data
            IUser? foundUser = authorizationService.CheckLogin(currentLogin);
            if (foundUser is not null) // found the user with such login, enter and check password
            {
                string? currentPassword = input.Read("Enter password:", drawer);
                if (string.IsNullOrEmpty(currentPassword) ||
                    !authorizationService.CheckPassword(foundUser, currentPassword))
                {
                    currentPassword = input.Read("Wrong password. Try again:", drawer);
                    if (string.IsNullOrEmpty(currentPassword) ||
                        !authorizationService.CheckPassword(foundUser, currentPassword))
                    {
                        input.Read("Wrong password. Exiting.... Press Enter.", drawer);
                        return null;
                    }
                    else // password is correct, create the user account
                    {
                        LogDistributor.GetInstance().Add(new Log(LogType.System, $"User {currentLogin}) entered the system"));
                        return authorizationService.CreateUserAccount(foundUser);
                    }
                }
                else // password is correct, create the user account
                {
                    LogDistributor.GetInstance().Add(new Log(LogType.System, $"User {currentLogin}) entered the system"));
                    return authorizationService.CreateUserAccount(foundUser);
                }
            }
            else // not found the user with such login, ask user if he wants to register
            {
                string? userReply = input.Read("Login not found. Do you want to register? (Y/N):", drawer);
                if (userReply?.ToUpper() == "Y") // yes, ask the password 
                {
                    string? currentPassword = input.Read("Enter new password:", drawer);
                    if (!authorizationService.CheckPasswordStrength(currentPassword))
                    {
                        currentPassword = input.Read("Password should be longer than 7 characters and contain at least one letter and one digit. Try again:", drawer);
                        if (!authorizationService.CheckPasswordStrength(currentPassword))
                        {
                            input.Read("Wrong password. Exiting.... Press Enter.", drawer);
                            return null;
                        }
                        else // password is OK, register user and create the user account
                        {
                            IUser? user = authorizationService.RegisterUser(currentLogin, currentPassword, Roles.Customer);
                            if (user == null) // some strange error
                            {
                                return null;
                            }
                            drawer.Write("Welcome!");
                            LogDistributor.GetInstance().Add(new Log(LogType.System, $"New user {currentLogin}) just registered and entered the system"));
                            return authorizationService.CreateUserAccount(user);
                        }
                    }
                    else // password is OK, register user and create the user account
                    {
                        IUser? user = authorizationService.RegisterUser(currentLogin, currentPassword, Roles.Customer);
                        if (user == null) // some strange error
                        {
                            return null;
                        }
                        drawer.Write("Welcome!");
                        LogDistributor.GetInstance().Add(new Log(LogType.System, $"New user {currentLogin}) just registered and entered the system"));
                        return authorizationService.CreateUserAccount(user);
                    }
                }
                else // user does not want to register
                {
                    input.Read("Exiting... Press Enter.", drawer);
                    return null;
                }
            }
        }


        public override ICollection<IMenuElement>? Execute()
        {
            UserAccount? userAccount = LoginRoutine();
            if (userAccount is null || userAccount.User is null)
            {
                return null; // exit
            }
            else
            {
                return new MenuDeterminerByRole(userAccount.User).GetMenuElements();
            }
        }
    }
}

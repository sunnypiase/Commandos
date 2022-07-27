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

        private bool CheckPasswordStrength(string? pass)
        {
            bool containsDigit = false;
            bool containsLetter = false;
            if (pass is null ||
                pass.Length < 8) return false;
            for (int i = 0; i < pass.Length; i++)
                if (pass[i] >= '0' && pass[i] <= '9')
                    containsDigit = true;
            for (int i = 0; i < pass.Length; i++)
                if (pass[i] >= 'A' && pass[i] <= 'Z' ||
                    pass[i] >= 'a' && pass[i] <= 'z')
                    containsLetter = true;
            return containsDigit && containsLetter;
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
                        drawer.Write("Wrong password. Exiting.... Press Enter.");
                        input.Read("", drawer);
                        return null;
                    }
                    else // password is correct, create the user account
                    {
                        return authorizationService.CreateUserAccount(foundUser);
                    }
                }
                else // password is correct, create the user account
                {
                    return authorizationService.CreateUserAccount(foundUser);
                }
            }
            else // not found the user with such login, ask user if he wants to register
            {
                string? userReply = input.Read("Login not found. Do you want to register? (Y/N):", drawer);
                if (userReply?.ToUpper() == "Y") // yes, ask the password 
                {
                    string? currentPassword = input.Read("Enter new password:", drawer);
                    if (!CheckPasswordStrength(currentPassword))
                    {
                        currentPassword = input.Read("Password should be longer than 7 characters and contain at least one letter and one digit. Try again:", drawer);
                        if (!CheckPasswordStrength(currentPassword))
                        {
                            drawer.Write("Wrong password. Exiting.... Press Enter.");
                            input.Read("", drawer);
                            return null;
                        }
                        else // password is OK, register user and create the user account
                        {
                            IUser? user = authorizationService.RegisterUser(currentLogin, currentPassword, Roles.Customer);
                            if (user == null) // some strange error
                            {
                                return null;
                            }
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
                        return authorizationService.CreateUserAccount(user);
                    }
                }
                else // user does not want to register
                {
                    drawer.Write("Exiting.");
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

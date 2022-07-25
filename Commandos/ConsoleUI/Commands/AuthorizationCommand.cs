using Commandos.Models.Users;
using Commandos.Role;
using Commandos.Services;
using Commandos.User;
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.Menu;
using ConsoleUI.Menu.MenuTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Commands
{
    internal class AuthorizationCommand : ICommand  // used for user's login

    {
        private string? currentLogin;
        private IInput input;
        private IDrawer drawer;

        AuthorizationService authorizationService;

        public AuthorizationCommand(IInput input, IDrawer drawer)
        {
            this.input = input;
            this.drawer = drawer;
            currentLogin = "";
            authorizationService = new();
        }

        private UserAccount? LoginRoutine()
        {
            // Enter login (nickname)
            currentLogin = input.Read("Enter nickname:", drawer);
            if (currentLogin == null || currentLogin == "")
                return null;
            // Check if nickname exists in the user data
            IUser? foundUser = authorizationService.CheckLogin(currentLogin);
            if (foundUser is not null) // found the user with such login, enter and check password
            {
                string? currentPassword = input.Read("Enter password:", drawer);
                if (currentPassword == null || currentPassword == "" ||
                    !authorizationService.CheckPassword(foundUser, currentPassword))
                {
                    currentPassword = input.Read("Wrong password. Try again:", drawer);
                    if (currentPassword == null || currentPassword == "" ||
                        !authorizationService.CheckPassword(foundUser, currentPassword))
                    {
                        drawer.Write("Wrong password. Exiting.");
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
                    string? currentPassword = input.Read("Enter password:", drawer);
                    if (currentPassword == null || currentPassword == "") // register new user and create the user account
                    {
                        currentPassword = input.Read("Password can not be empty. Try again:", drawer);
                        if (currentPassword == null || currentPassword == "")
                        {
                            drawer.Write("Wrong password. Exiting.");
                            return null;
                        }
                        else // password is OK, register user and create the user account
                        {
                            IUser? user = authorizationService.RegisterUser(currentLogin, currentPassword, Roles.Customer);
                            if (user == null) // some strange error
                                return null;
                            drawer.Write("Welcome!");
                            return authorizationService.CreateUserAccount(user);
                        }
                    }
                    else // password is OK, register user and create the user account
                    {
                        IUser? user = authorizationService.RegisterUser(currentLogin, currentPassword, Roles.Customer);
                        if (user == null) // some strange error
                            return null;
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


        public ICollection<IMenuElement>? Execute()
        {
            UserAccount? userAccount = LoginRoutine();
            if (userAccount is null || userAccount.User is null)
                return null; // exit
            else
                return new MenuDeterminerByRole(userAccount.User).GetMenuElements();

        }
    }
}

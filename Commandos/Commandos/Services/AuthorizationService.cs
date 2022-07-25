using Commandos.Models.Users;
using Commandos.Role;
using Commandos.User;
// using ConsoleUI.Drawers;  // Commandos does not see ConsoleUI

namespace Commandos.Services
{
    public class AuthorizationService
    {
        #region Fields
        private Roles currentRole = Roles.Customer;
        private string currentLogin = "";
        #endregion

        #region Constructors
        // A constructor not needed. UsersRepository.GetInstance() used to reach users data
        #endregion

        #region Methods
        public UserAccount LoginRoutine()
        {
            /* TODO
             * 	Enter login (nickname)
Check if nickname exists in the user data
If yes:
	Enter password
	Check password
	If correct, create the person
	If not correct, allow repeat once or exit
If not:
	Ask user if he wants to register
	If yes: enter password
		    add user with this login and password
		    save the users DB (serialize)
		    create the person
	If not, exit (return null)
             */
            return CreateUserAccount(); // TODO
        }

        private string ReadAndCheckLogin()
        {
            return ""; // TODO
        }

        private bool ReadAndCheckPassword()
        {
            return true;  // TODO
        }

        private bool RegisterLoginPassword()
        {
            return true;  // TODO
        }

        public IUser CreatePerson(string name, Roles role = Roles.Customer)
        {
            IUser user = new Commandos.User.User(name, Guid.NewGuid(), role);
            UsersRepository.GetInstance().AddUser(user);
            return user;
        }
        public UserAccount CreateUserAccount()
        {
            return new UserAccount(CreatePerson(currentLogin, currentRole));  // TODO
        }
        #endregion
    }
}

using Commandos.Logs;
using Commandos.Logs.InterfacesAndEnums;
using Commandos.Models.Users;
using Commandos.Role;
using Commandos.User;

namespace Commandos.Services
{
    public class AuthorizationService
    {
        #region Methods
        public IUser? CheckLogin(string nickname)
        // returns true of users repository contains this nickname
        {
            return UsersRepository.GetInstance().GetPersonByName(nickname);
        }

        private string EncryptOrDecryptPassword(string password)
        // in this case, encryption and decryption use the same operation :)
        {
            string result = "";
            for (int i = 0; i < password.Length; i++)
                result += (char)(password[i] ^ Int16.MaxValue);   // XOR with 1111111111111111
            return result;
        }

        public bool CheckPassword(IUser user, string password)
        // Encrypt the password and compare with the one saved in users repopository
        {
            return (user.EncryptedPassword == EncryptOrDecryptPassword(password));
        }

        public IUser RegisterUser(string name, string password, Roles role = Roles.Customer)
        // add new user to repository if he has just registered
        {
            IUser user = new Commandos.User.User(name, Guid.NewGuid(), role, EncryptOrDecryptPassword(password));
            UsersRepository.GetInstance().AddUser(user);
            return user;
        }
        public UserAccount? CreateUserAccount(IUser? user)
        {
            return user is null ? null : UserAccount.GetInstance(user);
        }
        #endregion
    }
}

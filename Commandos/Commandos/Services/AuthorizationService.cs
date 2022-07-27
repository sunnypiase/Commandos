using Commandos.Models.Users;
using Commandos.Role;
using Commandos.User;

namespace Commandos.Services
{
    public class AuthorizationService
    {
        #region Methods
        public IUser? CheckLogin(string nickname)
        // returns true if users repository contains this nickname
        {
            return UsersRepository.GetInstance().GetPersonByName(nickname);
        }

        private string EncryptOrDecryptPassword(string password)
        // in this case, encryption and decryption use the same operation :)
        {
            string result = "";
            for (int i = 0; i < password.Length; i++)
            {
                result += (char)(password[i] ^ Int16.MaxValue);   // XOR with 1111111111111111
            }

            return result;
        }

        public bool CheckPassword(IUser user, string password)
        // Encrypt the password and compare with the one saved in users repopository
        {
            return (user.EncryptedPassword == EncryptOrDecryptPassword(password));
        }
        public void ChangePassword(IUser user, string password)
        // Encrypt the password and set it to user
        {
            user.EncryptedPassword = EncryptOrDecryptPassword(password);
        }

        public bool CheckPasswordStrength(string? pass)
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

        public IUser RegisterUser(string name, string password, Roles role = Roles.Customer)
        // add new user to repository if he has just registered
        {
            IUser user = new Commandos.User.User(name, Guid.NewGuid(), role, EncryptOrDecryptPassword(password));
            UsersRepository.GetInstance().AddUser(user);
            return user;
        }
        public UserAccount? CreateUserAccount(IUser? user)
        {
            if (user is null)
            {
                return null;
            }
            else
            {
                UserAccount.GetInstance().User = user;
                return UserAccount.GetInstance();
            }
        }
        #endregion
    }
}

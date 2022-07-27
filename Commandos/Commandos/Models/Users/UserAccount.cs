using Commandos.User;

namespace Commandos.Models.Users
{
    public class UserAccount     // an entity that holds the current logged user
    {
        private static UserAccount? _instance;
        public IUser? User { get; set; } = null;  // default is null until the user is logged in
        public static UserAccount GetInstance(IUser? user = null)
        {
            if (_instance == null)
            {
                _instance = new UserAccount(user);
            }
            return _instance;
        }

        private UserAccount(IUser? user)
        {
            if (user is not null)
            {
                User = user;
            }
        }
    }
}

using Commandos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Models.Users
{
    public class UserAccount     // an entity that holds the current logged user
    {
        private static Lazy<UserAccount> _instance;
        public static UserAccount GetInstance(IUser? user = null) => _instance is null ? new UserAccount(user) : _instance.Value;
        public IUser? User { get; } = null;  // default is null until the user is logged in
        public UserAccount(IUser? user)
        {
            if (user is not null)
                User = user;
        }
    }
}

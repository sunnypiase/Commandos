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
        public IUser? User { get; set; } = null;  // default is null until the user is logged in

        public UserAccount(IUser? user)
        {
            if (user is not null)
                User = user;
        }
    }
}

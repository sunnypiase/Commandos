
using Commandos.Role;

namespace Commandos.User
{
    public interface IUser
    {
        public string Name { get; }
        public Guid Guid { get; }
        public Roles Role { get; set; }
        public string EncryptedPassword { get; set; } // needed to be saved to file and checked during login

    }
}

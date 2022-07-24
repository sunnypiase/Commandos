
using Commandos.Role;

namespace Commandos.User
{
    public interface IUser
    {
        public string Name { get; }
        public Guid Guid { get; }
        public Roles Role { get; }
    }

    public class User : IUser
    {
        public string Name { get; }
        public Guid Guid { get; }
        public Roles Role { get; }

        public User(string name, Guid guid, Roles role)
        {
            Name = name;
            Guid = guid;
            Role = role;
        }
    }
}

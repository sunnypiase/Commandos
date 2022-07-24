
using Commandos.Role;

namespace Commandos.User
{
    public interface IUser
    {
        public string Name { get; }
        public Guid Guid { get; }
        public Roles Role { get; }
    }
}

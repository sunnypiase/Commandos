
namespace ConsoleUI.User
{
    public interface IUser
    {
        public string UserName { get; }
        public Guid Guid { get; }
        public Roles Role { get; }
    }
}

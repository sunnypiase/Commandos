using Commandos.Serialize;
using Commandos.User;
using System.Collections;
using System.Runtime.Serialization;

namespace Commandos.Models.Users
{
    [KnownType(typeof(User.User))]
    [DataContract]
    public class UsersRepository : IEnumerable<IUser>
    {
        [DataMember(Name = "users")]
        private List<IUser> users;

        private static UsersRepository? instance;

        private UsersRepository()  // create empty repository
        {
            users = new List<IUser>();
        }

        public static UsersRepository GetInstance(UsersRepository repository = null) // create an instance
        {
            if (instance is null)
            {
                instance = repository ?? new();
            }
            return instance;
        }

        public List<IUser> AllUsers()
        {
            return users;
        }

        public IUser? GetPersonByID(Guid id)
        {
            return users.Find(u => u.Guid == id);
        }

        public IUser? GetPersonByName(string nickname)
        {
            return users.Find(u => u.Name.Equals(nickname));
        }

        public void AddUser(IUser? user)
        {
            if (user is not null)
            {
                users.Add(user);
            }
        }

        public void RemoveUser(IUser? user)
        {
            if (user is not null)
            {
                users.Remove(user);
            }
        }      
                
        public IEnumerator<IUser> GetEnumerator()
        {
            return this.users.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

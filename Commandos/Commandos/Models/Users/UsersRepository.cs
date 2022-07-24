using Commandos.Role;
using Commandos.User;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Commandos.Models.Users
{
    [DataContract]
    public class UsersRepository
    {
        [DataMember]
        private List<IUser> users;

        [XmlIgnore]
        private static UsersRepository instance;

        public static UsersRepository GetInstance()
        {
            return instance is null ? instance = new UsersRepository() : instance;
        }

        public List<IUser> AllUsers()
        {
            return users;
        }

        private UsersRepository()
        {
            ReadUsersFromFile();
            if (users is null) // this is a strange error but to avoid such situation we create new list
            {
                users = new List<IUser>();
            }
        }

        public IUser GetPerson(Guid id)
        {
            IUser user = users.Find(u => u.Guid == id);
            if (user is null) // (could not find user)
            {
                return null;
            }
            else
            {
                return user;
            }
        }

        public void RemovePerson(Guid id)
        {
            IUser user = GetPerson(id);
            if (user is null) // (could not find user)
            {
                ; // here we should define what to do. Probably, throw an exception
            }
            else
            {
                RemoveUser(user);
            }
        }

        public void AddUser(IUser user)
        {
            users.Add(user);
        }

        public void RemoveUser(IUser user)
        {
            users.Remove(user);
        }

        public void ReadUsersFromFile()
        {
            //TODO DownloaderProcessor.GetUserDataSerializer(new XmlSerialization<UsersRepository>).Load(instance);
        }

        public void SaveUsersToFile()
        {
            //TODO DownloaderProcessor.GetUserDataSerializer(new XmlSerialization<UsersRepository>).Save(instance);
        }

        public Roles GetRole(Guid id)
        {
            IUser user = GetPerson(id);
            if (user is null) // (could not find user)
            {
                return Roles.Customer;
            }
            else
            {
                return user.Role;
            }
        }

        public bool SetRole(Guid id, Roles role)
        {
            IUser user = GetPerson(id);
            if (user is null) // (could not find user)
            {
                return false;
            }
            else
            {
                user.Role = role;
                return true;
            }
        }
    }
}

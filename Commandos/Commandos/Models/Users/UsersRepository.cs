using Commandos.Role;
using Commandos.Serialize;
using Commandos.User;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Commandos.Models.Users
{

    [KnownType(typeof(Commandos.User.User))]
    [DataContract]
    public class UsersRepository
    {
        [DataMember(Name = "users")]
        private List<IUser> users;

        [XmlIgnore]
        private static UsersRepository? instance;

        private UsersRepository()  // create empty repository
        {
            users = new List<IUser>();
        }

        public static UsersRepository GetInstance() // create an instance: if it is not yet initialized then read from file
        {
            if (instance is null)
            {
                ReadUsersFromFile();
                if (instance is null) // some deserialization error
                    instance = new UsersRepository();
                if (instance.users is null) // also some error
                    instance.users = new List<IUser>();
            }
            return instance;
        }

        public List<IUser> AllUsers()
        {
            return users;
        }

        /* private UsersRepository()
        {
            ReadUsersFromFile();
            if (users is null) // this is a strange error but to avoid such situation we create new list
            {
                users = new List<IUser>();
            }
        }*/

        public IUser? GetPersonByID(Guid id)
        {
            IUser? user = users.Find(u => u.Guid == id);
            if (user is null) // (could not find user)
            {
                return null;
            }
            else
            {
                return user;
            }
        }

        public IUser? GetPersonByName(string nickname)
        {
            IUser? user = users.Find(u => u.Name == nickname);
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
            IUser? user = GetPersonByID(id);
            if (user is null) // (could not find user)
            {
                ; // TODO: here we should define what to do. Probably, throw an exception
            }
            else
            {
                RemoveUser(user);
            }
        }

        public void AddUser(IUser? user)
        {
            if (user is not null)
                users.Add(user);
            SaveUsersToFile();
        }

        public void RemoveUser(IUser? user)
        {
            if (user is not null)
                users.Remove(user);
            SaveUsersToFile();
        }

        public static void ReadUsersFromFile()
        {
            try
            {
                instance = DownloaderProcessor.GetUserDataSerializer(new XmlStreamSerialization<UsersRepository>()).Load();
            }
            catch (Exception ex)
            {
                instance = null;
                // TODO: need to log this exception
            }
        }

        public void SaveUsersToFile()
        {
            try
            {
                DownloaderProcessor.GetUserDataSerializer(new XmlStreamSerialization<UsersRepository>()).Save(instance);
            }
            catch (Exception ex)
            {
                // TODO: need to log this exception
            }
        }

        public Roles GetRole(Guid id)
        {
            IUser? user = GetPersonByID(id);
            if (user is null) // (could not find user)
            {
                return Roles.Customer;  // here were meant to be unknown since the user was not found
            }
            else
            {
                return user.Role;
            }
        }

        public bool SetRole(Guid id, Roles role)
        {
            IUser? user = GetPersonByID(id);
            if (user is null) // (could not find user)
            {
                return false;
            }
            else
            {
                user.Role = role;
                SaveUsersToFile();
                return true;
            }
        }
    }
}

using Commandos.Role;
using Commandos.Serialize;
using Commandos.User;
using System.Runtime.Serialization;

namespace Commandos.Models.Users
{

    [KnownType(typeof(User.User))]
    [DataContract]
    public class UsersRepository
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
            return users.Find(u => u.Name.Equals(nickname));
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
            {
                users.Add(user);
            }

            SaveUsersToFile();
        }

        public void RemoveUser(IUser? user)
        {
            if (user is not null)
            {
                users.Remove(user);
            }

            SaveUsersToFile();
        }

        /*public static void ReadUsersFromFile()
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
        }*/

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

using Commandos.User;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Commandos.Models.Users
{
    [DataContract]
    internal class UsersRepository
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
            //DownloaderProcessor.GetUserDataSerializer(new XmlSerialization<UsersRepository>).Load(instance);
        }

        public void SaveUsersToFile()
        {
            //DownloaderProcessor.GetUserDataSerializer(new XmlSerialization<UsersRepository>).Save(instance);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static UsersRepository GetInstance() => instance is null ? instance = new UsersRepository() : instance;

        public List<IUser> AllUsers() => users;

        private UsersRepository()
        {
            ReadUsersFromFile();
            if (users is null) // this is a strange error but to avoid such situation we create new list
                users = new List<IUser>();
        }

        public void AddUser(user: IUser)
        {
            users.Add(user);
        }

        public void RemoveUser(user: IUser)
        {
            users.Remove(user);
        }

        public void ReadUsersFromFile()
        {
            DownloaderProcessor.GetUserDataSerializer(new XmlSerialization<UsersRepository>).Load(instance);
        }

        public void SaveUsersToFile()
        {
            DownloaderProcessor.GetUserDataSerializer(new XmlSerialization<UsersRepository>).Save(instance);
        }
    }
}

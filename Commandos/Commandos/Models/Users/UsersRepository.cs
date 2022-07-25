﻿using Commandos.Role;
using Commandos.Serialize;
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
        private static UsersRepository? instance;

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
                ; // here we should define what to do. Probably, throw an exception
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
        }

        public void RemoveUser(IUser? user)
        {
            if (user is not null)
                users.Remove(user);
        }

        public void ReadUsersFromFile()
        {
            instance = DownloaderProcessor.GetUserDataSerializer(new XmlStreamSerialization<UsersRepository>()).Load();
        }

        public void SaveUsersToFile()
        {
            DownloaderProcessor.GetUserDataSerializer(new XmlStreamSerialization<UsersRepository>()).Save(instance);
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
                return true;
            }
        }
    }
}
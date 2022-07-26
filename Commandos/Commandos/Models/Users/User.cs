
using Commandos.Role;
using System.Runtime.Serialization;

namespace Commandos.User
{
    [DataContract]
    public class User : IUser
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "ID")]
        public Guid Guid { get; set; }

        [DataMember(Name = "Role")]
        public Roles Role { get; set; }

        [DataMember(Name = "EP")]
        public string EncryptedPassword { get; set; }

        public User(string name, Guid guid, Roles role, string encryptedPassword)
        {
            Name = name;
            Guid = guid;
            Role = role;
            EncryptedPassword = encryptedPassword;
        }

        public override string? ToString()
        {
            return $"Name: {Name}, Role: {Role}";
        }
    }
}

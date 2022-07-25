using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Services
{
    public class PersonStorageService
    {
        private readonly static Lazy<PersonStorageService> _instance = new();
        public static PersonStorageService Instance => _instance.Value;

        protected PersonStorageService() { }

        #region Methods

        public void AddPerson(IPerson)
        {

        }

        public IPerson GetPerson(Guid personId)
        {

        }

        public void RemovePerson()
        {

        }

        public IRole GetRole(Guid personId)
        {
            return null;
        }

        public void SetRole(Guid personId)
        {

        }

        #endregion
    }
}

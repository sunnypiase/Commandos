using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandos.Services
{
    public class PersonStorageService
    {
        private static PersonStorageService _instance;

        protected PersonStorageService() { }

        public static PersonStorageService Instance()
        {
            if (_instance == null)
                _instance = new PersonStorageService();
            return _instance;
        }

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

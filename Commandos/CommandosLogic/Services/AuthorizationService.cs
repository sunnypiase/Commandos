using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commandos.Models.Users;

namespace Commandos.Services
{
    internal class AuthorizationService
    {
        private UsersRepository usersData;

        public AuthorizationService()
        {
            usersData = UsersRepository.GetInstance();
        }

        public IUser LoginRoutine()
        {
            return null;
        }


    }
}

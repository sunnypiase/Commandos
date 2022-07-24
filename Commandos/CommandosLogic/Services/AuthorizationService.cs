using Commandos.Models.Users;
using Commandos.User;

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

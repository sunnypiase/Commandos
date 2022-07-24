using Commandos.Models.Users;
using Commandos.User;
// using ConsoleUI;
// ConsoleUI is not visible, so Program class is not visible

namespace Commandos.Services
{
    public class AuthorizationService
    {
        //#region Fields
        //private UsersRepository usersData; // local copy of the link to the users repository, just for faster work
        //                                   // we don't have a method to share usersData with others, it is used only here
        //#endregion

        //#region Constructors
        //public AuthorizationService()
        //{
        //    usersData = UsersRepository.GetInstance(); // if users repository is empty, it is created and read from disk
        //    // warning: usersData cannot be empty but can create 0 users
        //}
        //#endregion

        //#region Commands
        //public UserAccount LoginRoutine(IDrawer drawer)
        //{
        //    return CreateUserAccount(); // TODO
        //}
        //public void ExitProgram(IDrawer drawer)
        //{
        //    // Program.Quit(); // the method in Program class should close and save everything before exiting
        //                    // it also should call UsersRepository.GetInstance().SaveUsersToFile();
        //}
        //#endregion

        //#region Methods
        //private string ReadAndCheckLogin()
        //{
        //    return ""; // TODO
        //}

        //private bool ReadAndCheckPassword()
        //{
        //    return true;  // TODO
        //}

        //private bool RegisterLoginPassword()
        //{
        //    return true;  // TODO
        //}

        //private IUser CreatePerson()
        //{
        //    IUser user = new(); // TODO
        //    PersonStorageService.AddPerson(user);
        //    return user;
        //}
        //private UserAccount CreateUserAccount()
        //{
        //    return new UserAccount();  // TODO
        //}
        //#endregion
    }
}

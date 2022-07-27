using Commandos.Models.Carts;
using Commandos.Models.Users;
using Commandos.User;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands.AdminCommands
{
    public class RemoveSelectedUserFromRepositoryCommand : CommandOn<IUser>
    {

        public RemoveSelectedUserFromRepositoryCommand()
        {
        }

        public override object Clone()
        {
            return new RemoveSelectedUserFromRepositoryCommand(); ;
        }

        public override ICollection<IMenuElement>? Execute()
        {
            List<IMenuElement>? menuElements = new List<IMenuElement>();
            IUser? chosenPerson = commandTarget;
            if (chosenPerson == null)
            {
                menuElements.Add(new InfoElement("There is no selected user!"));
            }
            else
            {
                UsersRepository.GetInstance().RemoveUser(chosenPerson);
                CartsRepository? carts = CartsRepository.GetInstance();
                carts.Remove(carts.GetCart(chosenPerson));
                menuElements.Add(new InfoElement($"Successfully deleted user with nickname {chosenPerson.Name}"));
            }
            menuElements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return menuElements;
        }

    }
}

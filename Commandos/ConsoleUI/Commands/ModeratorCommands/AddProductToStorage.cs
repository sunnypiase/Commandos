using Commandos.User;
using ConsoleUI.Menu.MenuTypes;

namespace ConsoleUI.Commands.ModeratorCommands
{
    public class AddProductToStorage : CommandBase
    {
        public override ICollection<IMenuElement>? Execute()
        {
            List<IMenuElement> elements = new();
            elements.Add(new InfoElement("succesful"));
            elements.Add(new SelectableElement("continue", "0", new BackToHome()));
            return elements;
        }


    }//TODO do
}

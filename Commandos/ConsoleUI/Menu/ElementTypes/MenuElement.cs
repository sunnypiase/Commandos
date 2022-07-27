using ConsoleUI.Commands;

namespace ConsoleUI.Menu.MenuTypes
{
    public class SelectableElement : IMenuElement
    {
        private ICommand command;
        public DrawPriority Priority { get; }
        public string SignToCommand { get; }
        public string Title { get; }
        public bool isOnCursor { get; set; }

        public SelectableElement(string title, string sign, ICommand _command,
            DrawPriority priority = DrawPriority.Second)
        {
            command = _command;
            SignToCommand = sign;
            Title = title;
            Priority = priority;
            isOnCursor = false;
        }

        public ICollection<IMenuElement>? Run()
        {
            return command.Execute();
        }
    }
}

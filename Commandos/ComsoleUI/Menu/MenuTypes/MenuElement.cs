using ConsoleUI.Commands;
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;

namespace ConsoleUI.Menu.MenuTypes
{
    public enum DrawPriority
    {
        First,
        Second, 
        Third
    }

    public interface IMenuElement
    {
        public string Title { get; }
        public DrawPriority Priority { get; }
    }

    public class InfoElement : IMenuElement
    {
        public string Title { get; }
        public DrawPriority Priority { get; }

        public InfoElement(string title,
            DrawPriority priority = DrawPriority.First)
        {
            Title = title;
            Priority = priority;
        }
    }

    public class SelectableElement : IMenuElement
    {
        private ICommand command;
        public DrawPriority Priority { get; }
        public string SignToCommand { get; }
        public string Title { get; }

        public SelectableElement(string title, string sign, ICommand _command,
            DrawPriority priority = DrawPriority.Second)
        {
            command = _command;
            SignToCommand = sign;
            Title = title;
            Priority = priority;
        }

        public void Run(IDrawer drawer, IInput input)
        {
            command.Execute();
        }
    }
}

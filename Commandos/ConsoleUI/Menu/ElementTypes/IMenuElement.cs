namespace ConsoleUI.Menu.MenuTypes
{
    public interface IMenuElement
    {
        public string Title { get; }
        public DrawPriority Priority { get; }
    }
}
